using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public string cpName; // Name of the checkpoint
    public GameObject nextCheckpoint; // Reference to the next checkpoint
    public GameObject visualRepresentation; // Reference to the visual representation of the checkpoint
    public bool isLastCheckpoint; // Is this the last checkpoint?
    public int checkpointSFXIndex = 1; // Index of the checkpoint sound effect in the AudioManager
    public bool loadNextSceneOnActivation; // Should this checkpoint load the next scene?


    void Start()
    {
        // Hide the next checkpoint initially if it exists
        if (nextCheckpoint != null)
        {
            nextCheckpoint.SetActive(false);
        }

        // Check if the player should be moved to this checkpoint
        if (PlayerPrefs.GetString(SceneManager.GetActiveScene().name + "_cp") == cpName)
        {
            MovePlayerToCheckpoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the checkpoint
        if (other.gameObject.tag == "Player")
        {
            // Play checkpoint sound
            if (AudioManagerBgmSound.instance != null)
            {
                AudioManagerBgmSound.instance.PlaySFX(checkpointSFXIndex);
            }
            // Save the checkpoint name in PlayerPrefs
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "_cp", cpName);
            // Save the checkpoint position in PlayerPrefs
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_cp_x", transform.position.x);
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_cp_y", transform.position.y);
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_cp_z", transform.position.z);
            Debug.Log("Player Hit " + cpName);

            // Show the next checkpoint when this one is activated
            if (nextCheckpoint != null)
            {
                nextCheckpoint.SetActive(true);
            }

            // Deactivate the visual representation of the current checkpoint
            if (visualRepresentation != null)
            {
                visualRepresentation.SetActive(false);
            }

            // If this is the last checkpoint, load the next scene
            if (isLastCheckpoint)
            {
                LoadNextScene();
            }
        }
    }

    public void MovePlayerToCheckpoint()
    {
        // Get the saved checkpoint position
        float x = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_cp_x", transform.position.x);
        float y = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_cp_y", transform.position.y);
        float z = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_cp_z", transform.position.z);

        // Disable the CharacterController to move the player without interference
        PlayerController.instance.GetComponent<CharacterController>().enabled = false;
        // Move the player to the saved checkpoint position
        PlayerController.instance.transform.position = new Vector3(x, y, z);
        // Re-enable the CharacterController
        PlayerController.instance.GetComponent<CharacterController>().enabled = true;
        Debug.Log("Player standing at " + cpName);
    }
    private void LoadNextScene()
    {
        // Load the next scene based on your specific scene management logic
        // For example, load the next scene in the build order
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Debug.Log("Loading next scene...");
    }
}
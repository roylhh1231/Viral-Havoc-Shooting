using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string NextScene;
    public float waitToEndLevel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player collided with the exit box.");
            // AudioManager.instance.PlayLevelVictory();
            GameManager.instance.ending = true;
            StartCoroutine(EndLevelCo());
        }
    }

    private IEnumerator EndLevelCo()
    {
        Debug.Log("Ending level coroutine started.");
        PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "_cp", ""); //clear out the check point database
        Debug.Log("Attempting to load scene: " + NextScene); // Debugging line
        yield return new WaitForSeconds(waitToEndLevel);
        Debug.Log($"Loading scene: '{NextScene}'"); // Check what is being loaded
        SceneManager.LoadScene(NextScene);

    }

}
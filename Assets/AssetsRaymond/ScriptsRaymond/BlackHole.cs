using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackHole : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InteractionPromptUI promptUI; // Reference to the InteractionPromptUI component
    private int requiredKeys = 5; // Number of keys required to activate the collider

    public string InterationPrompt => _prompt;

    public SceneController sceneController; // Reference to the SceneController

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the collider is triggered by the player
        {
            CheckKeysAndHandleInteraction(other);
        }
    }

    private void CheckKeysAndHandleInteraction(Collider player)
    {
        if (GameManager.instance.counter >= requiredKeys)
        {
            // If the player has enough keys, trigger the collider's functionality
            promptUI.Setup("Enter"); // Setup to show 'Enter' prompt, suggesting they can proceed
            // Use GameManager's method to change the scene
            GameManager.instance.LoadNextScene();
        }
        else
        {
            // If the player does not have enough keys, show a message
            promptUI.Setup("5 Keys Required"); // Show '5 Keys Required' prompt
            Debug.Log("More keys needed: You need 5 keys to proceed.");
        }
    }

    public bool Interact(Interactor interactor)
    {
        // Define the interaction behavior, could be opening a portal, changing scene, etc.
        // Example: if keys are enough, maybe trigger something immediately
        return true;  // Returning true as a placeholder, assuming interaction is always 'successful'
    }
}

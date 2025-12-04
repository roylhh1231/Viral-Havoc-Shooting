using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithAccess : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt = "Press E to unlock door";  // default prompt
    [SerializeField] private Animator DoorAnimation; // Reference to the Animator component
    [SerializeField] private GameObject AccessCard; // Reference to the AccessCard GameObject
    [SerializeField] private InteractionPromptUI promptUI; // Reference to the InteractionPromptUI component
    public int openDoorSFX = 0;
    public string InterationPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        StartCoroutine(ManageDoorAnimation());
        return true;
    }

    private IEnumerator ManageDoorAnimation()
    {
        if (PlayerController.instance.allGuns[PlayerController.instance.currentGun].gameObject == AccessCard)
        {
            // Remove the AccessCard from the allGuns list
            PlayerController.instance.RemoveGun(AccessCard);

            DoorAnimation.SetBool("OpenDoor", true); // Start opening door animation
            
            // Play door sound
            if (AudioManagerBgmSound.instance != null)
            {
            AudioManagerBgmSound.instance.PlaySFX(openDoorSFX);
            }

            yield return null; // Proceed to next frame

            // Change the GameObject's layer to Default after the door opens
            gameObject.layer = LayerMask.NameToLayer("Default");

        }
        else
        {
            // Show "Access Card needed" and revert to "Press E to unlock door" after 3 seconds
            if (promptUI != null)
            {
                promptUI.Setup("Access Card needed");
                yield return new WaitForSeconds(3); // Wait for 3 seconds
                promptUI.Setup(_prompt); // Revert to initial prompt
            }
            Debug.Log("Access Denied: You need the AccessCard to open this door.");
        }
    }
}

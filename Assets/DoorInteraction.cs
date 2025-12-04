using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;  // default prompt
    [SerializeField] public Animator DoorAnimation; // Reference to the Animator component
    [SerializeField] public InteractionPromptUI promptUI; // Reference to the InteractionPromptUI component
   
    public int openDoorSFX = 0;
    public string InterationPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        StartCoroutine(ManageDoorAnimation());
        return true;
    }

    private IEnumerator ManageDoorAnimation()
    {

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
}

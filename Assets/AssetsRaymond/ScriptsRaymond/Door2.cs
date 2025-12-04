using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private Animator DoorAnimation; // Reference to the Animator component


    public int OpenDoorSFXIndex = 0; // Index of the Open Door sound effect in the AudioManager


    public string InterationPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        StartCoroutine(ManageDoorAnimation());
        return true;
    }

    private IEnumerator ManageDoorAnimation()
    {
        DoorAnimation.SetBool("OpenDoor", true); // Start opening door animation
                                                 // Play checkpoint sound
        if (AudioManagerBgmSound.instance != null)
        {
            AudioManagerBgmSound.instance.PlaySFX(OpenDoorSFXIndex);
        }
        gameObject.layer = LayerMask.NameToLayer("Default"); // Change the layer to Default
        yield return null;
    }
}

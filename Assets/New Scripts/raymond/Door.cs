using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private Animator DoorAnimation; // Reference to the Animator component

    public string InterationPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        StartCoroutine(ManageDoorAnimation());
        return true;
    }

    private IEnumerator ManageDoorAnimation()
    {
        DoorAnimation.SetBool("OpenDoor", true); // Start opening door animation
        yield return new WaitForSeconds(3.0f); // Door remains open for 3 seconds
        DoorAnimation.SetBool("OpenDoor", false); // Reset the parameter after the duration
    }
}

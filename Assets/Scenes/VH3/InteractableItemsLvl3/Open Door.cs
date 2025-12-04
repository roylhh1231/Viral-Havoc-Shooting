using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteractable
{

    [SerializeField] private string _prompt;
    [SerializeField] private Animator DoorAnimation; // Reference to the Animator component
    public string InterationPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        StartCoroutine(ManageDoorAnimation()); // can open and close
        //DoorAnimation.SetBool("OpenDoor", true); // Start opening door animation

        //Debug.Log("Open Board");
        //HintClue.instance.OpenBoard();

        gameObject.layer = LayerMask.NameToLayer("Default");

        return true;
    }

    private IEnumerator ManageDoorAnimation()
    {
        DoorAnimation.SetBool("OpenDoor", true); // Start opening door animation
        GetComponent<Collider>().enabled = false;
        //yield return null;
        yield return new WaitForSeconds(3.0f); // Door remains open for 3 seconds
        //DoorAnimation.SetBool("OpenDoor", false); // Reset the parameter after the duration
    }

}
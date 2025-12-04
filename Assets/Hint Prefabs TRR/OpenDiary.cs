using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDiary : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InterationPrompt => _prompt;

    public DoorWithDIary DoorWithDIary;

    public bool Interact(Interactor interactor)
    {
        //Debug.Log("Open Board");
        Hints.instance.OpenDiary1();
        DoorWithDIary.diary = true;
        return true;
    }
}

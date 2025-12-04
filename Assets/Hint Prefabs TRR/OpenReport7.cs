using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenReport7 : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InterationPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        //Debug.Log("Open Board");
        Hints.instance.OpenReport7();
        return true;
    }
}

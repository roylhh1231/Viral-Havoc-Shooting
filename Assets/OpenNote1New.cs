using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNote1New : MonoBehaviour, IInteractable
{

    [SerializeField] private string _prompt;
    public string InterationPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        //Debug.Log("Open Board");
        HintLevel2.instance.OpenNote1();
        return true;
    }

}
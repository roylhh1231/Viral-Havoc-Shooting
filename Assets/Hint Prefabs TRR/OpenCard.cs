using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCard : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public Gun Battery; // Reference to the Laser Pistol Gun component
    public string InterationPrompt => _prompt;
    
    public bool Interact(Interactor interactor)
    {
        PlayerController player = interactor.GetComponent<PlayerController>();
        //Debug.Log("Open Board");
        Hints.instance.OpenCard();
        player.AddGun(Battery); // Add the Laser Pistol to the player's allGuns list
        Debug.Log("Picked up Gripping Gun");

        this.gameObject.SetActive(false); // Optionally disable the gun object on the ground
        return true;

    }
}

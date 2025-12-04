using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCell : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt = "Press E to pick up Cell";

    public string InterationPrompt => _prompt;


    public Gun Battery; // Reference to the Laser Pistol Gun component
    public int pickupGunSFX = 4; // Index of the checkpoint sound effect in the AudioManager

    public bool Interact(Interactor interactor)
    {
        PlayerController player = interactor.GetComponent<PlayerController>();
        if (player != null && Battery != null)
        {
            // Play checkpoint sound
            

            player.AddGun(Battery); // Add the Laser Pistol to the player's allGuns list
            Debug.Log("Picked up Gripping Gun");

            this.gameObject.SetActive(false); // Optionally disable the gun object on the ground
            return true;
        }
        return false;
    }
}

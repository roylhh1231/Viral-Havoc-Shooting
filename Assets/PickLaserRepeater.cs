using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickLaserRepeater : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt = "Press E to pick up Laser Repeater";
    public string InterationPrompt => _prompt;

    public Gun laserRepeater; // Reference to the Laser Snipper Gun component
    public int pickupGunSFX = 4; // Index of the checkpoint sound effect in the AudioManager

    public bool Interact(Interactor interactor)
    {
        PlayerController player = interactor.GetComponent<PlayerController>();
        if (player != null && laserRepeater != null)
        {
            // Play checkpoint sound
            if (AudioManagerBgmSound.instance != null)
            {
                AudioManagerBgmSound.instance.PlaySFX(pickupGunSFX);
            }
            player.AddGun(laserRepeater); // Add the Laser Snipper to the player's allGuns list
            Debug.Log("Picked up Laser Repeater");
            this.gameObject.SetActive(false); // Optionally disable the gun object on the ground
            return true;
        }
        return false;
    }
}
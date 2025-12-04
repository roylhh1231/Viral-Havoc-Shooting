using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickLaserPistol : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt = "Press E to pick up Laser Pistol";
    public string InterationPrompt => _prompt;

    public Gun laserPistol; // Reference to the Laser Pistol Gun component
    public int pickupGunSFX = 4; // Index of the checkpoint sound effect in the AudioManager

    public bool Interact(Interactor interactor)
    {
        PlayerController player = interactor.GetComponent<PlayerController>();
        if (player != null && laserPistol != null)
        {
            // Play checkpoint sound
            if (AudioManagerBgmSound.instance != null)
            {
                AudioManagerBgmSound.instance.PlaySFX(pickupGunSFX);
            }

            player.AddGun(laserPistol); // Add the Laser Pistol to the player's allGuns list
            Debug.Log("Picked up Laser Pistol");
            this.gameObject.SetActive(false); // Optionally disable the gun object on the ground
            return true;
        }
        return false;
    }
}
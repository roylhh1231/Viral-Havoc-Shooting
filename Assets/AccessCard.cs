using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessCard : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InterationPrompt => _prompt;

    public Gun card; // Reference to the Laser Snipper Gun component
    public int pickUpCard = 5; // Index of the checkpoint sound effect in the AudioManager

    public bool Interact(Interactor interactor)
    {
        PlayerController player = interactor.GetComponent<PlayerController>();
        if (player != null && card != null)
        {
            if (AudioManagerBgmSound.instance != null)
            {
                AudioManagerBgmSound.instance.PlaySFX(pickUpCard);
            }

            player.AddGun(card); // Add the Laser Snipper to the player's allGuns list
            Debug.Log("Picked up Access Card");
            this.gameObject.SetActive(false); // Optionally disable the gun object on the ground

            return true;
        }
        return false;
    }
}
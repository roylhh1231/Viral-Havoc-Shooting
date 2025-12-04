using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPistolGun : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt = "Press E to pick up Pistol Gun";
    public string InteractionPrompt => _prompt;
    public string InterationPrompt => throw new System.NotImplementedException();

    public Gun pistolGun; // Reference to the Laser Snipper Gun component

    public bool Interact(Interactor interactor)
    {
        PlayerController player = interactor.GetComponent<PlayerController>();
        if (player != null && pistolGun != null)
        {
            player.AddGun(pistolGun); // Add the Laser Snipper to the player's allGuns list
            Debug.Log("Picked up Pistol Gun");
            this.gameObject.SetActive(false); // Optionally disable the gun object on the ground
            return true;
        }
        return false;
    }
}

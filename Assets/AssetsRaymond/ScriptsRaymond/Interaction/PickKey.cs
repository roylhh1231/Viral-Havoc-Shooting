using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKey : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt = "Press E to pick up key";
    [SerializeField] private string keyID; // Unique ID for each key

    public int PickUpKeySFXIndex = 5; // Index of the checkpoint sound effect in the AudioManager

    public string InterationPrompt => _prompt;

    private void Start()
    {

    }

    public bool Interact(Interactor interactor)
    {
        // Play checkpoint sound
        if (AudioManagerBgmSound.instance != null)
        {
            AudioManagerBgmSound.instance.PlaySFX(PickUpKeySFXIndex);
        }
        Destroy(this.gameObject);

        GameManager.instance.IncreasetheScore();
        HUDManager.instance.RefreshHUD();


        return true;
    }
}

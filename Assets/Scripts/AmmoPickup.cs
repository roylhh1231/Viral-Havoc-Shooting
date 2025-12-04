using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    public int PickupBulletSFXIndex = 6; // Index of the pixkupbullet sound effect in the AudioManager

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController.instance.activeGun.GetAmmo();
            // Play checkpoint sound
            if (AudioManagerBgmSound.instance != null)
            {
                AudioManagerBgmSound.instance.PlaySFX(PickupBulletSFXIndex);
            }
            Destroy(gameObject);
        }
    }
}
        
    


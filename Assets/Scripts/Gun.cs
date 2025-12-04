using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;

    public bool canAutoFire;
    public float fireRate;
    [HideInInspector]
    public float fireCounter;

    public int currentAmmo, pickAmount;
    public int maxAmmo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fireCounter > 0)
        {
            fireCounter -= Time.deltaTime;
        }
    }

    public void GetAmmo()
    {
        // Add ammo but do not exceed the maximum ammo limit
        currentAmmo += pickAmount;
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo; // Set current ammo to max ammo if it exceeds the limit
        }

        // Update the ammo count on the UI
        UIController.instance.AmmoText.text = "" + currentAmmo;
    }
}

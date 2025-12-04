using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float moveSpeed, lifeTime;
    public Rigidbody RB;
    public GameObject ImpactEffect;
    public int damage = 10; // Amount of damage the bullet deals

    void Start()
    {
        if (RB == null)
        {
            RB = GetComponent<Rigidbody>();
        }
        RB.useGravity = false;
        RB.isKinematic = false;
    }

    void Update()
    {
        RB.velocity = transform.forward * moveSpeed; // make the bullet move forward

        lifeTime -= Time.deltaTime; // count down the lifetime

        if (lifeTime <= 0)
        {
            Destroy(gameObject); // destroy the object when lifetime is zero
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet hit: " + other.gameObject.name); // Log the name of the object hit

        float offset = 0.7f;
        Vector3 newPosition = transform.position - transform.forward * offset; // adjust the position based on offset
        Debug.Log("Impact position: " + newPosition); // Debug log for position
        Debug.Log("Impact effect: " + (ImpactEffect != null ? "Assigned" : "Not Assigned")); // Debug log for checking if the effect is assigned

        if (ImpactEffect != null)
        {
            Instantiate(ImpactEffect, newPosition, transform.rotation); // spawn the ImpactEffect at the adjusted position & rotation
        }
        else
        {
            Debug.LogError("ImpactEffect prefab is not assigned.");
        }

        // Check if the bullet hit an object with the IDamageable interface
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage, false); // Apply damage
        }

        Destroy(gameObject); // destroy the bullet on collision
    }
}
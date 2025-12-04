using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TwinBController : MonoBehaviour
{
    public float shootRange = 15f; // Shooting range
    public int currentHealth = 100; // Enemy health
    public float shootInterval = 0.05f; // Time interval between each shot
    public int bulletsPerShot = 5; // Number of bullets per shot

    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    public Transform firePoint;
    public GameObject bullet;

    private bool isDead = false; // Flag to check if the enemy is dead
    private bool isShooting = false; // Flag to control shooting
    public float shootDelay = 1f; // Delay before the first shot

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // If the enemy is dead, ignore further damage

        currentHealth -= damage; // Deduct health based on damage amount
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true; // Set the dead flag
        animator.SetTrigger("die");
        animator.SetBool("isShooting", false);
        animator.SetBool("isChasing", false);
        agent.enabled = false;
        // Disable collider to prevent further interactions
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }
        // Disable the Animator to prevent any state changes
        animator.enabled = false;
        CancelInvoke("FireBullet"); // Stop shooting when dead
    }

    void Update()
    {
        if (isDead) return; // If the enemy is dead, skip the update logic

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Rotate to face the player
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        directionToPlayer.y = 0; // Keep the direction strictly horizontal
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        if (distanceToPlayer <= shootRange)
        {
            RangeAttack();
        }
        else
        {
            ChasePlayer();
        }
    }

    private void RangeAttack()
    {
        if (!isShooting)
        {
            agent.isStopped = true;
            animator.SetBool("isShooting", true);
            animator.SetBool("isChasing", false);
            InvokeRepeating("FireBullet", shootDelay, shootInterval); // Start shooting at intervals with a delay
            isShooting = true;
        }
    }

    private void FireBullet()
    {
        if (bullet && firePoint)  // Ensure the bullet prefab and fire point are correctly set
        {
            for (int i = 0; i < bulletsPerShot; i++)
            {
                // Calculate the spread for each bullet
                float spreadAngle = Random.Range(-5f, 5f);
                Quaternion spreadRotation = Quaternion.Euler(0, spreadAngle, 0);

                // Calculate the direction to the player with spread
                Vector3 directionToPlayer = spreadRotation * (player.position - firePoint.position).normalized;

                // Instantiate the bullet and set its position and direction
                GameObject newBullet = Instantiate(bullet, firePoint.position, Quaternion.LookRotation(directionToPlayer));

                Rigidbody rb = newBullet.GetComponent<Rigidbody>();  // Get the Rigidbody component of the bullet
                if (rb)
                {
                    rb.velocity = directionToPlayer * newBullet.GetComponent<BulletController>().moveSpeed;  // Set the bullet's speed
                }
            }
        }
    }

    private void ChasePlayer()
    {
        if (isShooting)
        {
            CancelInvoke("FireBullet"); // Stop shooting when chasing
            isShooting = false;
        }

        agent.isStopped = false;
        agent.SetDestination(player.position);
        animator.SetBool("isChasing", true);
        animator.SetBool("isShooting", false);
    }
}

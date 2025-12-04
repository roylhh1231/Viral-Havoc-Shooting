using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public string NextSceneName;

    public float meleeRange = 20f; // Melee range
    public float attackRange = 5f; // Attack range
    public float rangeAttackThreshold = 50f; // Health threshold to activate range attack

    public int currentHealth = 100; // Boss health
    public Slider HealthBar;

    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    public Transform firePoint;
    public GameObject bullet;

    private bool isTeleporting = false;
    private float teleportTimer = 0f;
    private float teleportDelay = 2f; // 2 seconds delay to simulate 50 frames at 25 fps
    private float teleportDistanceOffset = 3f; // Distance offset for teleport
    private float postTeleportPause = 1f; // Time to pause after teleport

    private float shootCooldown = 5f; // Shooting duration in seconds
    private float shootTimer = 0f; // Timer to track shooting duration

    private bool isDead = false; // Flag to check if the boss is dead

    // New variables for controlling fire rate
    private float fireRate = 0.5f; // Interval between bullets
    private float nextFireTime = 0f; // Time when the next bullet can be fired

    private int MachineGunSFXIndex = 17;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // If the boss is dead, ignore further damage

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
        animator.SetBool("isAttacking", false);
        animator.SetBool("isChasing", false);
        animator.SetBool("isTeleporting", false);
        agent.enabled = false;
        // Disable collider to prevent further interactions
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

    }

    void Update()
    {
        if (isDead) return; // If the boss is dead, skip the update logic

        HealthBar.value = currentHealth;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        Quaternion lookRotation = Quaternion.LookRotation((player.position - transform.position).normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        if (isTeleporting)
        {
            agent.isStopped = true;
            teleportTimer += Time.deltaTime;
            if (teleportTimer >= teleportDelay)
            {
                TeleportToPlayer();
                isTeleporting = false;
                teleportTimer = 0f;
            }
            return;
        }

        if (distanceToPlayer <= meleeRange)
        {
            if (distanceToPlayer <= attackRange)
            {
                MeleeAttack();
            }
            else if (currentHealth <= rangeAttackThreshold)  // Player is within melee but not attack range
            {
                if (shootTimer < shootCooldown)
                {
                    RangeAttack(); // Choose to range attack instead of chasing
                }
                else
                {
                    StopShootingAndTeleport();
                }
            }
            else
            {
                ChasePlayer(); // Default behavior if range mode not activated
            }
        }
        else
        {
            TriggerTeleport(); // Player is out of melee range, trigger teleport
        }
    }

    private void MeleeAttack()
    {
        agent.isStopped = true;
        animator.SetBool("isAttacking", true);
        animator.SetBool("isChasing", false);
        animator.SetBool("isTeleporting", false);
        animator.SetBool("isShooting", false);
        shootTimer = 0f; // Reset shoot timer when melee attacking
    }

    private void RangeAttack()
    {
        agent.isStopped = true;  // Optionally stop movement when shooting
        animator.SetBool("isShooting", true);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isChasing", false);
        animator.SetBool("isTeleporting", false);
        Shoot();
    }

    private void Shoot()
    {
        if (shootTimer >= shootCooldown)
        {
            StopShootingAndTeleport();
            return;
        }

        shootTimer += Time.deltaTime;

        // Check if it's time to fire the next bullet
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate; // Update the time for the next bullet
            FireBullet();
        }
    }

    private void FireBullet()
    {
        if (bullet && firePoint)  // Ensure the bullet prefab and fire point are correctly set
        {
            // Calculate the direction to the player
            Vector3 directionToPlayer = (player.position - firePoint.position).normalized;

           /* if (AudioManagerBgmSound.instance != null)
            {
                AudioManagerBgmSound.instance.PlaySFX(MachineGunSFXIndex);
            }*/

            // Instantiate the bullet and set its position and direction
            GameObject newBullet = Instantiate(bullet, firePoint.position, Quaternion.LookRotation(directionToPlayer));

            

            Rigidbody rb = newBullet.GetComponent<Rigidbody>();  // Get the Rigidbody component of the bullet
            if (rb)
            {
                rb.velocity = directionToPlayer * newBullet.GetComponent<BulletController>().moveSpeed;  // Set the bullet's speed
            }
        }
    }

    private void StopShootingAndTeleport()
    {
        shootTimer = 0f;
        animator.SetBool("isShooting", false);
        TriggerTeleport();
    }

    private void ChasePlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
        animator.SetBool("isChasing", true);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isTeleporting", false);
        animator.SetBool("isShooting", false);
        shootTimer = 0f; // Reset shoot timer when chasing
    }

    private void TriggerTeleport()
    {
        animator.SetBool("isTeleporting", true);
        animator.SetBool("isChasing", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isShooting", false);
        isTeleporting = true;
        teleportTimer = 0f;
        //agent.ResetPath();
    }

    private void TeleportToPlayer()
    {
        agent.enabled = false;
        Vector3 teleportPosition = player.position + player.forward * teleportDistanceOffset;
        transform.position = teleportPosition;
        agent.enabled = true;
        StartCoroutine(PostTeleportPause());
    }

    private IEnumerator PostTeleportPause()
    {
        yield return new WaitForSeconds(postTeleportPause);
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }
}

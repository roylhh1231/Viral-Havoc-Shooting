using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TwinAController : MonoBehaviour
{
    public float attackRange = 5f; // Attack range
    public int currentHealth = 100; // Enemy health

    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    private bool isDead = false; // Flag to check if the enemy is dead

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
        animator.SetBool("isAttacking", false);
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

        if (distanceToPlayer <= attackRange)
        {
            MeleeAttack();
        }
        else
        {
            ChasePlayer();
        }
    }

    private void MeleeAttack()
    {
        agent.isStopped = true;
        animator.SetBool("isAttacking", true);
        animator.SetBool("isChasing", false);
    }

    private void ChasePlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
        animator.SetBool("isChasing", true);
        animator.SetBool("isAttacking", false);
    }
}

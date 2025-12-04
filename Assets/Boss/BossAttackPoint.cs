using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPoint : MonoBehaviour
{
    public int attackDamage = 10;
    public BossController boss;

    void Start()
    {
        if (boss == null)
        {
            boss = GetComponentInParent<BossController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (boss != null && boss.currentHealth > 0)
        {
            if (other.CompareTag("Player"))
            {
                PlayerHealthController playerHealth = other.GetComponent<PlayerHealthController>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(attackDamage, true);
                }
            }
        }
    }

    void Update()
    {
        if (boss != null && boss.currentHealth <= 0)
        {
            GetComponent<Collider>().enabled = false;
        }
    }
}


using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public int attackDamage = 10;
    public Enemy2 enemy; // 引用敌人的脚本

    void Start()
    {
        if (enemy == null)
        {
            enemy = GetComponentInParent<Enemy2>(); // 确保获取敌人脚本的引用
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (enemy != null && enemy.HP > 0)
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
        if (enemy != null && enemy.HP <= 0)
        {
            GetComponent<Collider>().enabled = false; // 禁用 BoxCollider
        }
    }
}

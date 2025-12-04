using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    Transform player;
    public float attackRange = 5f;
    public int attackDamage = 5;
    public Transform attackPoint;
    private bool hasAttacked = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackPoint = animator.transform.Find("AttackPoint"); // 确保你的敌人有一个名为"AttackPoint"的子物体
        hasAttacked = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > attackRange)
        {
            animator.SetBool("isAttacking", false);
        }

        // 确保攻击动画只执行一次伤害
        if (!hasAttacked && stateInfo.normalizedTime >= 0.5f) // 当动画播放到一半时触发攻击
        {
            ApplyDamage();
            hasAttacked = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // Apply damage to the player
    private void ApplyDamage()
    {
        Collider[] hitPlayers = Physics.OverlapSphere(attackPoint.position, attackRange);

        foreach (Collider player in hitPlayers)
        {
            PlayerHealthController playerHealth = player.GetComponent<PlayerHealthController>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage, true);
            }
        }
    }
}

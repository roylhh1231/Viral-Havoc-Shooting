using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    AudioSource audioSource;

    public float chaseRange = 10f;
    public float attackRange = 5f;

    public AudioClip monsterSound;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = animator.GetComponent<AudioSource>();
        agent.speed = 3.5f;

        if (monsterSound != null && audioSource != null && !audioSource.isPlaying)
        {
            audioSource.clip = monsterSound;
            audioSource.Play();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > chaseRange)
            animator.SetBool("isChasing", false);
        if (distance < attackRange)
            animator.SetBool("isAttacking", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        // implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
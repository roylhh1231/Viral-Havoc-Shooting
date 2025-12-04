using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkState : StateMachineBehaviour
{

    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;

    Transform player;
    public float chaseRange = 10;

    [SerializeField] private int minWaypointIndex = 0;
    [SerializeField] private int maxWaypointIndex = 5;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1.5f;

        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
        foreach (Transform t in go.transform)
            wayPoints.Add(t);

        PrintWayPoints(); // 调用打印方法，调试用

        SetNextDestination();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            SetNextDestination();


        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange)
            animator.SetBool("isChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    private void SetNextDestination()
    {
        if (wayPoints.Count == 0) return;

        int randomIndex = Random.Range(minWaypointIndex, Mathf.Min(maxWaypointIndex, wayPoints.Count));
        Debug.Log("Selected WayPoint Index: " + randomIndex + " Position: " + wayPoints[randomIndex].position);
        agent.SetDestination(wayPoints[randomIndex].position);
    }

    private void PrintWayPoints()
    {
        for (int i = 0; i < wayPoints.Count; i++)
        {
            Debug.Log("WayPoint Index: " + i + " Position: " + wayPoints[i].position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float minDistance = 1.5f;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.position).magnitude <= minDistance)
        {
            agent.SetDestination(player.position);
        }
    }
}

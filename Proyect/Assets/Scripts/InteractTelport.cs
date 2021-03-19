using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class InteractTelport : MonoBehaviour
{
    [SerializeField]
    Transform from;
    [SerializeField]
    Transform to;
    GameObject player;
    NavMeshAgent playerNav;

    bool teleport = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerNav = player.GetComponent<NavMeshAgent>();
    }

    private void OnMouseDown()
    {
        playerNav.destination = from.position;
        teleport = true;
        
    }
    private void Update()
    {
        if (teleport)
        {
            if (!playerNav.pathPending)
            {
                if (playerNav.remainingDistance <= playerNav.stoppingDistance)
                {
                    if (!playerNav.hasPath || playerNav.velocity.sqrMagnitude == 0f)
                    {
                        playerNav.ResetPath();
                        playerNav.Warp(to.position);
                        teleport = false;
                    }
                }
            }
        }
    }
}


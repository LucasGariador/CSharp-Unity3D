using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChestInteract : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent playerNav;
    Animation anim;
    public Transform openPoint;
    bool openChest = false;
    bool isOpen = false;

    private void Start()
    {
        anim = GetComponent<Animation>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerNav = player.GetComponent<NavMeshAgent>();
    }

    private void OnMouseDown()
    {
        if (!isOpen)
        {
            playerNav.SetDestination(openPoint.position);
            openChest = true;
        }
    }
    private void Update()
    {
        if (openChest)
        {
            if (!playerNav.pathPending)
            {
                if (playerNav.remainingDistance <= playerNav.stoppingDistance)
                {
                    if (!playerNav.hasPath || playerNav.velocity.sqrMagnitude == 0f)
                    {
                        anim.Play();
                        player.GetComponent<Animator>().SetTrigger("chestTrigger");
                        openChest = false;
                        isOpen = true;
                    }
                }
            }
        }
    }
}

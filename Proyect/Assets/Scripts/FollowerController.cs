using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowerController : MonoBehaviour
{
    [SerializeField]
    Transform playerInFront;

    NavMeshAgent character;

    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        character.SetDestination(playerInFront.position);
        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        _animator.SetFloat("forwardSpeed", speed);
    }
}
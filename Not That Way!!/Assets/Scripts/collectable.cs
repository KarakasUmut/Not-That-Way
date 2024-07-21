using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class collectable : MonoBehaviour
{
    public Transform Target;
   

    private ParticleSystem _particleSystem;
    private Animator animator;
    NavMeshAgent Agent;

    private void Start()
    {
      
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Stop();
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Agent.destination = Target.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            _particleSystem.Play();
            Agent.enabled = true;
            animator.enabled = true;
        }

       if (other.gameObject.CompareTag("Obstacle"))
       {
           
            Destroy(gameObject);
            
       }

    }
    private void OnTriggerExit(Collider other)
    {
        _particleSystem.Stop();
        
    }
}

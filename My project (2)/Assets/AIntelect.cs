using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIntelect : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    private UnityEngine.AI.NavMeshAgent AI_agent;
    public bool TF;
    void Start()
    {
        AI_agent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("PLAUER");
        TF = false;

    }
    void FixedUpdate()
    {
        if (TF == true)
        {
            AI_agent.SetDestination(player.transform.position);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PLAUER")
        {
            TF = true;
            animator.SetBool("ifRun", true);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        
        
            TF = false;
            animator.SetBool("ifRun", false);
        
    
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "PLAUER")
        {
            TF = true;
        }
    }
}

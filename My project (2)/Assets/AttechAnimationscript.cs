using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttechAnimationscript : MonoBehaviour
{
    public Animator animator;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PLAUER")
        {
            animator.SetBool("ifAttecht", true);
        }
    }
    public void OnTriggerExit(Collider collider)
    {

            animator.SetBool("ifAttecht", false);
    }
}

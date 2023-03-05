using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabRayFYCK : MonoBehaviour
{
    public GameObject leftRay;
    public GameObject rightRay;
    public XRDirectInteractor LeftDirectGrab;
    public XRDirectInteractor RightDirectGrab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftRay.SetActive(LeftDirectGrab.interactablesSelected.Count == 0);
        rightRay.SetActive(RightDirectGrab.interactablesSelected.Count == 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class animationlf : MonoBehaviour
{
    public InputActionProperty pinchAnimatinAction;
    public Animator handAnimarot;
    public InputActionProperty gripAnimatinActin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimatinAction.action.ReadValue<float>();
        handAnimarot.SetFloat("Trigger",triggerValue);
        float gripValue = gripAnimatinActin.action.ReadValue<float>();
        handAnimarot.SetFloat("Grip", gripValue);
    }
}

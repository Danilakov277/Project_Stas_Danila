using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GrabPhysics : MonoBehaviour
{
    public InputActionProperty grabInputSource;
    public float radius = 0.1f;
    public LayerMask grabLayer;
    private FixedJoint fixedJoint;
    private bool IsGrabbing = false;
    void FixedUpdate()
    {
        bool isGrabButtonPresed = grabInputSource.action.ReadValue<float>() > 0.1f;
        if (isGrabButtonPresed && !IsGrabbing)
        {
            Collider[] nearbyCollider = Physics.OverlapSphere(transform.position, radius, grabLayer, QueryTriggerInteraction.Ignore);
            if (nearbyCollider.Length > 0)
            {
                Rigidbody nearbyRigidbody = nearbyCollider[0].attachedRigidbody;
                fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.autoConfigureConnectedAnchor = false;
                if (nearbyRigidbody)
                {
                    fixedJoint.connectedBody = nearbyRigidbody;
                    fixedJoint.connectedAnchor = nearbyRigidbody.transform.InverseTransformPoint(transform.position);
                }
                else
                {
                    fixedJoint.connectedAnchor = transform.position;
                }
                IsGrabbing = true;

            }
        }
        else if (!isGrabButtonPresed && IsGrabbing) 
        {
            IsGrabbing = false;
            if (fixedJoint)
            {
                Destroy(fixedJoint);
            }
        }

    }
}

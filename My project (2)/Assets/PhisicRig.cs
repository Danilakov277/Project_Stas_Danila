using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhisicRig : MonoBehaviour
{
    public Transform playerHead;
    public Transform leftController;
    public Transform rightController;
    public CapsuleCollider bodyCollider;

    public ConfigurableJoint headJoint;
    public ConfigurableJoint leftHandJoint;
    public ConfigurableJoint rightHandJoint;

    public float bodyHeightMin;
    public float bodyHeightMax;

    // Update is called once per frame
    void FixedUpdate()
    {
        bodyCollider.height = Mathf.Clamp(playerHead.localPosition.y, bodyHeightMin, bodyHeightMax);
        bodyCollider.center = new Vector3(playerHead.localPosition.x, bodyCollider.height / 2, playerHead.localPosition.z);

        rightHandJoint.targetPosition = rightController.localPosition;
        rightHandJoint.targetRotation = rightController.localRotation;

        leftHandJoint.targetPosition = leftController.localPosition;
        leftHandJoint.targetRotation = leftController.localRotation;

        headJoint.targetPosition = playerHead.localPosition;
    }
}

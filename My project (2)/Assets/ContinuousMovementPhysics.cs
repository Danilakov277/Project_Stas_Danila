using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ContinuousMovementPhysics : MonoBehaviour
{
    public float speed = 1;
    public float turnSpeed = 60;
    private float jumpVelocity = 7;
    public float jumpHeight = 1.5f;
    public bool onlyMoveWhenGrounded = false;
    public InputActionProperty moveInputSource;
    public InputActionProperty turnInputSource;
    public InputActionProperty jumpInputSource;
    public Rigidbody rb;
    public LayerMask groundLayer;
    public CapsuleCollider bodyCollider;
    public Transform turnSource;
    public Transform directionSource;
    private float inputTurnAxis;

    private Vector2 inputMoveAxis;
    private bool isGrounded;

    void Update()
    {
        inputMoveAxis = moveInputSource.action.ReadValue<Vector2>();
        inputTurnAxis = turnInputSource.action.ReadValue<Vector2>().x;

        bool jumpInput = jumpInputSource.action.WasPressedThisFrame();
        if (jumpInput && isGrounded) 
        {
            jumpVelocity = Mathf.Sqrt(2 * -Physics.gravity.y * jumpHeight);
            rb.velocity = Vector3.up * jumpVelocity;
        }
        
    }
    private void FixedUpdate() 
    {
        isGrounded = CheckIfGrounded();

        if (!onlyMoveWhenGrounded || (onlyMoveWhenGrounded && isGrounded)) 
        {
            Quaternion yaw = Quaternion.Euler(0, directionSource.eulerAngles.y, 0);
            Vector3 direction = yaw * new Vector3(inputMoveAxis.x, 0, inputMoveAxis.y);

            Vector3 targetMovePosition = rb.position + direction * Time.fixedDeltaTime * speed;
            Vector3 axis = Vector3.up;
            float angle = turnSpeed * Time.fixedDeltaTime * inputTurnAxis;
            Quaternion q = Quaternion.AngleAxis(angle, axis);

            rb.MoveRotation(rb.rotation * q);
            Vector3 newPosition = q * (targetMovePosition - turnSource.position) + turnSource.position;
            rb.MovePosition(newPosition);
        }
        
    }
    public bool CheckIfGrounded()
    {
        Vector3 start = bodyCollider.transform.TransformPoint(bodyCollider.center);
        float rayLenght = bodyCollider.height / 2 - bodyCollider.radius + 0.05f;

        bool hasHit = Physics.SphereCast(start, bodyCollider.radius, Vector3.down, out RaycastHit htiInfo, rayLenght, groundLayer);

        return hasHit;
    }
}

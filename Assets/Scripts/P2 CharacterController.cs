using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2CharacterController : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 10;
    public float pushForce = 3.0f;
    public ControllerColliderHit contact;

    CharacterController characterController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        var hInput = Input.GetAxis("Horizontal 2");
        var vInput = Input.GetAxis("Vertical 2");

        if (characterController.isGrounded)
        {
            //This prevents the player from moving backwards
            //if (vInput < 0)
            //{
            //    vInput *= -1;
            //}

            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;
            if (Input.GetButtonDown("Jump 2"))
            {
                moveVelocity.y = jumpSpeed;
            }
        }
        //Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        contact = hit;

        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null && !body.isKinematic)
        {
            body.velocity = hit.moveDirection * pushForce;
        }
    }
}

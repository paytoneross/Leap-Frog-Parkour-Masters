using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 10;
 
    CharacterController characterController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;
 
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");
 
        if(characterController.isGrounded)
        {
            //This prevents the player from moving backwards
            if(vInput < 0)
            {
                vInput *= -1;
            }

            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;
            if(Input.GetButtonDown("Jump"))
            {
                moveVelocity.y = jumpSpeed;
            }
        }
        //Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }
}
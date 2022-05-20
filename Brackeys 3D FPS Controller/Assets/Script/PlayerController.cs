using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -9.81f;

    public float maxFallSpeed = -50f;

    public float minFallSpeed = -2f;

    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
//GroundCheck
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
//Velocity Sets
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = minFallSpeed;
        }
        if (velocity.y < maxFallSpeed)
            { velocity.y = maxFallSpeed;}

//INPUTS
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
//Walk
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
//Gravity
        velocity.y += gravity * Time.deltaTime;
//Move character using its velocity vector 3
        controller.Move(velocity * Time.deltaTime);
    }
}

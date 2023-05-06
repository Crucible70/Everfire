using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundmask;

    Vector3 velocity;
    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -10f;
        }
        if (Input.GetButton("Sprint"))
        {
            speed = 24f;
        }
       else
       {
           speed = 12f;
       }
        if (Input.GetButton("Crouch"))
        {
            controller.height = 1;
            controller.center = new Vector3(0, 1, 0);
            speed = 6f;
            jumpHeight = 1.5f;
        }
        else
        {
            controller.height = 2;
            controller.center = new Vector3(0, 0, 0);
            jumpHeight = 1f;
        }
        if (Input.GetButtonUp("Crouch") && isGrounded)
        {
            velocity.y = 6;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -4f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
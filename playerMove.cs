using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    Vector3 moveVector;
    CharacterController controller;
    public bool isGrounded;
    public float speed = 5.0f;
    public float sprintSpeed = 10.0f;
    public float gravity = 20.0f;
    private float fallSpeed;

    void Start()
    {

        controller = GetComponent<CharacterController>();


    }

    void FixedUpdate()
    {
        PlayerMovement();
        Grounded();

    }


    void Fall()
    {
        if (!isGrounded)
        {
            fallSpeed += gravity * Time.deltaTime;
        }
        else
        {
            if(fallSpeed > 0)
            {
                fallSpeed = 0;
            }
        }

        controller.Move(new Vector3(0, -fallSpeed, 0) * Time.deltaTime);
    }
    void PlayerMovement()
    {
        moveVector = Vector3.zero;

        if (controller.isGrounded == false)
        {
            moveVector += Physics.gravity;
        }


        moveVector = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveVector = transform.TransformDirection(moveVector);
        moveVector = moveVector * speed;



        //sprint mechanic
        if (Input.GetKey("left shift"))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = 5.0f;
        }
        //gravity
        moveVector.y = moveVector.y - (gravity * Time.deltaTime);

        //move the controller
        controller.Move(moveVector * Time.deltaTime);

    }

    void Grounded()
    {
        isGrounded = (Physics.Raycast(transform.position, -transform.up, controller.height / 1.8f));

    }
}

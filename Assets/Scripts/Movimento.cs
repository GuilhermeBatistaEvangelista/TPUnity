using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;

    public float speed = 20f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 fallVelocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        if(isGrounded && fallVelocity.y<0){
            fallVelocity.y=-2f;
        }
           float x= Input.GetAxis("Horizontal");
       float z= Input.GetAxis("Vertical");

       Vector3 move= transform.right * x + transform.forward*z;
       controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded){
            fallVelocity.y=Mathf.Sqrt(jumpHeight * -2f*gravity);
        }
       fallVelocity.y+=gravity*Time.deltaTime;
       controller.Move(fallVelocity*Time.deltaTime);
    }
}

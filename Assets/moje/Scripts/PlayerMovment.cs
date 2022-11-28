using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
  
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -1f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.2f;
    [SerializeField] private float jumpHeight = 1f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Animator animator;
    [SerializeField] private int rotationSpeed = 720;
    private bool moovment = true;
    private Vector3 moveDirection;
    private Vector3 velocity;
    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //movment 
        if (moovment)
        {
            Move();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
      
       
        velocity.y += gravity * Time.deltaTime;//grawitacja 
        controller.Move(velocity * Time.deltaTime);
    }
    void BlockMovment()
        {
            moovment = false;
        }
        void UnlockMovment()
        {
            moovment = true;
        }
        void Move()//mechanika chodzenia oraz rotacji 
        {       
            float x = Input.GetAxis("Horizontal");
            moveDirection = new Vector3(x, 0, 0);
            moveDirection *= speed;
            controller.Move(moveDirection * Time.deltaTime);
            if (moveDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        if ((moveDirection != Vector3.zero) && (isGrounded))
        {
            animator.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
        }
        else if (moveDirection == Vector3.zero)
        {
            animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime); 
        }
        }
  

    void Jump()
        {
            velocity.y = Mathf.Sqrt(jumpHeight *-2f* gravity);//mechanika skoku 
            animator.SetTrigger("Jump");//animacja skoku
        }

    
}




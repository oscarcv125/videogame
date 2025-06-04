using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 5;

    private Vector2 movement;
    private Rigidbody2D rb;

    private Animator animator; // Reference to the Animator component
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>(); // Update movement based on input

        if (movement.x != 0 || movement.y != 0) {// Check if there is any movement input
        
            animator.SetFloat("X", movement.x); // Set the X parameter in the Animator
            animator.SetFloat("Y", movement.y); // Set the Y parameter in the Animator
            animator.SetBool("IsWalking", true); // Set the isMoving parameter in the Animator to true
        } else {
            animator.SetBool("IsWalking", false); // Set the isMoving parameter in the Animator to false
        }
    }

    private void FixedUpdate()
    {
        //if (movement.x != 0 || movement.y != 0) // Check if there is any movement input
       
          
           // rb.linearVelocity = movement * speed; // Set the linear velocity of the Rigidbody2D based on movement and speed
        rb.AddForce(movement * speed); // Apply force to the Rigidbody2D based on movement and speed
    }
}

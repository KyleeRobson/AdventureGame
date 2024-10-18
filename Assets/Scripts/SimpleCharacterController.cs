using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;
    public bool isGrounded = false;
    public float maxHealth = 1f;
    public float currentHealth;

    public HealthBar healthbar;

    private CharacterController controller;
    private Vector3 velocity;
    private Transform thisTransform;


    private void Start()
    {
        //Cache references to components
        controller = GetComponent<CharacterController>();
        thisTransform = transform;

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }


    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnXAxis();
    }

    private void MoveCharacter()
    {
        //Horizontal Movement
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(x:moveInput, y:0f, z:0f) * (moveSpeed * Time.deltaTime);
        controller.Move(move);


        //Jumping
        if (Input.GetButtonDown("Jump")  && isGrounded)
        {
            velocity.y = Mathf.Sqrt(f: jumpForce * -2f * gravity);
        }
    }


    private void ApplyGravity()
    {
       

        
        //Apply gravity when not grounded
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f; //Reset velocity when grounded
        }


        //Apply the velocity to the controller
        controller.Move(motion: velocity * Time.deltaTime);
    }

    private void KeepCharacterOnXAxis()
    {
        //Maintain character on the same z-axis position
        Vector3 currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }


    private void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);

        Debug.Log("test3 " + currentHealth);
    }

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("test");
        
        if (collision.gameObject.CompareTag("enemy"))
        {
            TakeDamage(.1f);
            Debug.Log("test2");
        }
    }
}


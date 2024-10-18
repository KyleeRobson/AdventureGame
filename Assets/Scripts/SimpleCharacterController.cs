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

    public float maxMana = 1f;
    public float currentMana;

    public ManaBar manaBar=new ManaBar();

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

        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }


    private void Update()
    {
        CharacterAction();
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnXAxis();
    }

    private void CharacterAction()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            SpendMana(.1f);
            Debug.Log("test");
        }
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
    }

    public void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("enemy"))
        {
            TakeDamage(.1f);
        }
    }

    public void SpendMana(float ManaSpent)
    {
        currentMana -= ManaSpent;

        manaBar.SetMana(currentMana);
    }
}


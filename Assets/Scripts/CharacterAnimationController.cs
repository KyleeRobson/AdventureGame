using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
   private Animator animator;


        private void Start()
    {
        // Cache the Animator component attached to CharacterArt
        animator= GetComponent<Animator>();
    }


    private void Update()
    {
        HandleAnimations();
    }



    private void HandleAnimations()
    {
      

        // Handle Double Jump
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger(name: "DoubleJumpTrigger");
        }

        // Handle Fall
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger(name: "FallTrigger");
        }

        // Handle Hit
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger(name: "HitTrigger");
        }


        //Handle running and idleing
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetTrigger(name: "RunTrigger");
        }
        else
        {
            animator.SetTrigger(name: "IdleTrigger");
        }


        //Handle jumping
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger(name: "JumpTrigger");
        }


        //Handle Wall Jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger(name: "WallJumpTrigger");
        }


    }
}

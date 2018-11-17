using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Joystick joystick;
    public float runSpeed = 40f;

    public bool mobileBuild = false;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool playerIsOnAir = false;
    float rb_Speed = 0;

    void Start()
    {
        if (!mobileBuild)
        {
            if (joystick == null)
            {
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(mobileBuild)
        {
            horizontalMove = joystick.Horizontal;

        }
        else
        horizontalMove = Input.GetAxis("Horizontal");    

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        Debug.Log(animator.GetBool("IsJumping"));

        if (Input.GetButtonDown("Fire1"))
        {
            
            if(OnGround() && !playerIsOnAir)
            {
                jump = true;
                playerIsOnAir = true;
                animator.SetBool("IsJumping", true);
                animator.SetBool("PlayerLands", false);
                
            }
            
        }

        /* if (Input.GetButtonDown("Crouch"))
         {
             crouch = true;
         }
         else if (Input.GetButtonUp("Crouch"))
         {
             crouch = false;
         }*/
       

    }

    //tsekataan onko pelaaja maassa
    public bool OnGround()
    {
        return controller.IsPlayerOnGround();
    }

    public void OnLanding()
    {

        if (OnGround())
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("PlayerLands", true);
            playerIsOnAir = false;
            Debug.Log("osuin maahan");
        }
        
    }

    public void OnCrouching(bool isCrouching)
    {
        //animator.SetBool("IsCrouching", isCrouching);
    }


    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;
      
   
    }
}

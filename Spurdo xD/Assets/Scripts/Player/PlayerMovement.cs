using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tower
{


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
        float startZPosition = 0;

        void Start()
        {
            startZPosition = transform.position.z;
            if (!GameManager.Instance.IsMobilebuild())
            {
                if (joystick == null)
                {
                    return;
                }
            }
            jump = false;
            animator.SetBool("IsJumping", false);
            animator.SetBool("PlayerLands", false);
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.IsMobilebuild())
            {
                horizontalMove = joystick.Horizontal;

            }
            else
                horizontalMove = Input.GetAxis("Horizontal");

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));



            if (Input.GetButtonDown("Fire1"))
            {

                if (OnGround() && !playerIsOnAir)
                {
                    jump = true;
                    playerIsOnAir = true;
                    animator.SetTrigger("Jump");
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
            Vector3 pos = transform.position;
            pos.x = 1.127f;
            pos.z = -5.83f;
            transform.position = pos;
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

            //transform.position = new Vector3(transform.position.x, transform.position.y, startZPosition);

        }
    }
}
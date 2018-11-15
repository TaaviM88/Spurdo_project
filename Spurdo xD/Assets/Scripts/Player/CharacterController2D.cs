using System;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField]
    private float m_JumpForce = 400f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField]
    private float lowJumpMultiplier = 2f;
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;
    [Range(0, .3f)]
    [SerializeField]
    private float m_MovementSmoothing = .05f;
    [SerializeField] private bool m_AirControl = false;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching
    public GameObject PlayerSprite;

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded; // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody m_Rigidbody;
    private bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        if(OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }

        if(OnCrouchEvent == null)
        {
            OnCrouchEvent = new BoolEvent();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;


        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider[] colliders = Physics.OverlapSphere(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for(int i = 0; i< colliders.Length; i++)
        {
            if(colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

    }

    public void Move(float move, bool crouch, bool jump)
    {
        if(!crouch)
        {
            /*if(Physics.OverlapSphere(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }*/
        }

        if(m_Grounded || m_AirControl)
        {
            // If crouching
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                // Reduce the speed by the crouchSpeed multiplier
                move *= m_CrouchSpeed;

                // Disable one of the colliders when crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            Vector3 targetVelocity = new Vector3(move * 10f, m_Rigidbody.velocity.y, 0);
            //m_Rigidbody.velocity = Vector3.SmoothDamp(m_Rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            //m_Rigidbody.velocity = targetVelocity;
            transform.Translate(Vector3.right * move * 0.1f);

            //transform.Rotate(Vector3.up * move * -6.5f);
            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }

            if (m_Grounded && jump)
            {
                m_Grounded = false;
                m_Rigidbody.AddForce(new Vector3(0f, m_JumpForce, 0f), ForceMode.Force);

                if (m_Rigidbody.velocity.y < 0)
                {
                    m_Velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
                }
                else if (m_Rigidbody.velocity.y > 0)
                {
                    m_Rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
                }
            }
        }
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        PlayerSprite.transform.Rotate(0, 180, 0);
        //transform.Rotate(0f, 180f, 0f);
    }
}

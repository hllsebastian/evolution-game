using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;

    [Header("Movement")]
    private float horizontalMovement = 0f;
    [SerializeField] private float movementSpeed;
    [Range(0, 0.3f)][SerializeField] private float movementDamping;
    private Vector3 velocity = Vector3.zero;
    private bool lookingRight = true;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector3 boxDimentions;
    [SerializeField] private bool isGrounded;

    [Header("Animation")]
    private Animator animator;

    private bool jumpBool = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * movementSpeed;
        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded)
        {
            rb2D.velocity = new Vector2(0, 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBool = true;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxDimentions, 0f, groundLayer);


        Move(horizontalMovement * Time.fixedDeltaTime, jumpBool);

        jumpBool = false;
    }

    private void Move(float movementDirection, bool jumpParameter)
    {
        if (!isGrounded)
        {
            Vector3 velocidadObjetivo = new Vector2(movementDirection, rb2D.velocity.y);
            rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocity, movementDamping);

            if (movementDirection > 0 && !lookingRight)
            {
                Turn();
            }
            else if (movementDirection < 0 && lookingRight)
            {
                Turn();
            }
        }

        if (isGrounded && jumpParameter)
        {
            isGrounded = false;
            rb2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void Turn()
    {
        lookingRight = !lookingRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.position, boxDimentions);
    }
}

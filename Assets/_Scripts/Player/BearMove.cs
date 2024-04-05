using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMove : MonoBehaviour
{
 
    [Header("Movimiento")]
    public float movespeed;

    [Header("Componentes")]
    public Rigidbody2D theRB;

    [Header("Animator")]
    public Animator anim;
    public SpriteRenderer theSR;


    public float knockBackLength, knockBackForce;
    private float knocBackCounter;
    
    
    private bool lookingRight = true;


    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        Moving();
    }

    void Moving()
    {
     
            theRB.velocity = new Vector2(movespeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

            if (theRB.velocity.x < 0 && lookingRight)
            {
            
            Turn();
                
            }
            else if (theRB.velocity.x > 0 && !lookingRight)
            {
            
            Turn();
            
            }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
    }

    private void Turn()
    {
        lookingRight = !lookingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public bool IsMoving
    {
        get { return Mathf.Abs(theRB.velocity.x) > 0.01f; } // Considera el oso en movimiento si su velocidad es mayor a un pequeño umbral.
    }

}
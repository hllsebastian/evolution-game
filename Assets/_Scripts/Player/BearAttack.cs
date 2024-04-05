using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAttack : MonoBehaviour
{
    
    public string allowedTarget = "CanBeDestroyedByBear";
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float damage = 10;
    private Animator animator;

    private BearMove bearMove;

    private void Start()
    {
        animator = GetComponent<Animator>();
        bearMove = GetComponent<BearMove>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !bearMove.IsMoving && !UIManager.isPaused)
        {
            Golpe();
        }
    }
    private void Golpe()
    {
        animator.SetBool("isAttacking", true);

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("CanBeDestroyedByBear"))
            {
                colisionador.transform.GetComponent<EnemyHealth>().RestarVida(damage); ;
            }
        }         
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
    public void ResetAttack()
    {
        animator.SetBool("isAttacking", false);
    }

}

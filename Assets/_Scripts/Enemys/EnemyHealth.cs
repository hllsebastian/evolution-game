using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float vidaInicial = 100;
    private float vidaActual; 

    public string etiquetaAtaquePermitido = "CanBeDestroyedByBear";

    // Este método se llama al iniciar el juego
    void Start()
    {
        vidaActual = vidaInicial; 
    }

    public void RestarVida(float cantidad)
    {
      
            vidaActual -= cantidad; 
            Debug.Log("Vida restante: " + vidaActual); 

            if (vidaActual <= 0)
            {
               DerrotarObjetivo();
            }
        
    }

    void DerrotarObjetivo()
    {
        Debug.Log("El objetivo ha sido derrotado."); 
        Destroy(gameObject); 
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float vidaInicial = 20;
    private float vidaActual;

    public string etiquetaAtaquePermitido = "CanBeDestroyedByBear";

    // Este m�todo se llama al iniciar el juego
    void Start()
    {
        vidaActual = vidaInicial;
    }

    public void RestarVida(float cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            DerrotarObjetivo();
        }
    }

    void DerrotarObjetivo()
    {
        Destroy(gameObject);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProp : MonoBehaviour, IDestroyable
{
    [SerializeField] private AttackTypeEnum attackToDestroy;

    public void DetroyObject()
    {
        Destroy(gameObject);
    }

    public void DetroyObject(AttackTypeEnum attackType)
    {
        if (attackToDestroy == attackType)
        {
            Destroy(gameObject);
        }
    }
}

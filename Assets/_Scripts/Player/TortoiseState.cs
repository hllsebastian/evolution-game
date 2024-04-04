using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortoiseState : MonoBehaviour
{
    [SerializeField] private AttackTypeEnum attackType;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IDestroyable destroyable))
        {
            destroyable.DetroyObject(attackType);
        }
    }
}

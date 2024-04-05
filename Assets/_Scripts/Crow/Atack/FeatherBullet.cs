using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FeatherBullet : MonoBehaviour
{
    [SerializeField] private AttackTypeEnum attackType;
    [SerializeField] float speed;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDestroyable destroyable))
        {
            destroyable.DetroyObject(attackType);
            Destroy(gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
}

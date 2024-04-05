using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FeatherBullet : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("TriangleEnemy"))
        {
            Debug.Log("PLAYEERRR NOT");
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("DESTROOYYY ENEMYY");
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("WALL");
            Destroy(gameObject);
        }
    }
}

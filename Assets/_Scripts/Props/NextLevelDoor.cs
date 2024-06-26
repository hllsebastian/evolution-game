using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelDoor : MonoBehaviour
{
    [SerializeField] private bool canChangeScene = false;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canChangeScene)
        {
            SceneManagerObject.Instance.LoadNextScene();
        }
    }

    public void KeyPickedUp()
    {
        canChangeScene = true;
        spriteRenderer.enabled = true;
        animator.SetTrigger("Activate");
    }
}

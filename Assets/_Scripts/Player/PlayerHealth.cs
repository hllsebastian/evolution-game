using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    [SerializeField] private GameObject playerDestroyParticles;
    [SerializeField] private float reloadSceneWaitTime;

    private void Start()
    {
        parentObject = transform.parent.gameObject;
    }

    public void TakeDamage()
    {
        Instantiate(playerDestroyParticles, transform.position, Quaternion.identity);
        SceneManagerObject.Instance.ReloadScene(reloadSceneWaitTime);
        Destroy(parentObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class CrowShoot : MonoBehaviour
{
    [Header("Shooter")]
    [SerializeField] GameObject featherPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] private float firingRate;

    [Header("Animation")]
    private Animator animator;


    private float lastBulletTime = 0;
    static public bool canShoot = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) && CanShoot())
        {
            Debug.Log("SHOOT B");
            ShootFeather();
        }
    }

    void ShootFeather()
    {
        animator.SetTrigger("Attack");

        lastBulletTime = Time.time;
        GameObject FeatherBullet = Instantiate(featherPrefab, firePoint.position, firePoint.rotation);

        Destroy(FeatherBullet, 2.0f);

    }

    private bool CanShoot()
    {
        if (Time.time < firingRate + lastBulletTime)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

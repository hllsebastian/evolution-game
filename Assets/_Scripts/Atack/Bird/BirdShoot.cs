using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class BirdShoot : MonoBehaviour
{
    [SerializeField] GameObject featherPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] private float firingRate;
    private float lastBulletTime = 0;
    static public bool canShoot = true;

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

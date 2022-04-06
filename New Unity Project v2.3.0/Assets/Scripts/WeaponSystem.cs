using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] Rigidbody bullet;
    public float bulletSpeed = 5f;
    public float bulletOffsetX = 0.5f;
    public float bulletOffsetY = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
        }
    }

    void FireWeapon()
    {

        Rigidbody shot;

        shot = Instantiate(bullet, firePoint.position, firePoint.rotation);
        shot.velocity = firePoint.forward * bulletSpeed;
    }
}


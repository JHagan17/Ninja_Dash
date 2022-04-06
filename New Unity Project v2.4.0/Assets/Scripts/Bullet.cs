using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static int damage = 20;

    public Transform firePoint;
    public Transform bullet;
    public float maxShotDistance;

    private void OnTriggerEnter(Collider hitInfo)
    {
        EnemyController enemy = hitInfo.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        
        Destroy(gameObject);
        print("shuriken hit!");
    }

    // Update is called once per frame
    void Update()
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        float shotDistance = Vector3.Distance(firePoint.position, bullet.position);

        if (shotDistance >= maxShotDistance)
        {
            Destroy(gameObject);
        }
    }
}

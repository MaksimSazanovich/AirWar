using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;    
    [SerializeField] private GameObject bullet;
    [SerializeField] private float time;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private void FixedUpdate()
    {
        Shoot();
    }

    private void Shoot()
    {
        //RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);

        //if (hitInfo)
        //{
        //    Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
        //    if (enemy != null)
        //    {
        //        enemy.TakeDamage(damage);
        //    }

        //    Instatiate(impactEffect, hitInfo.point, Quaternion.identity);
        //}
       
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * speed, ForceMode2D.Impulse);
    }
}

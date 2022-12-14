using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonSingle : PlayerCannonBase
{
    [SerializeField] private Transform bulletStartPosition;
    protected override void Shoot()
    {
        var bullet = bulletsPool.GetBullet();
        if (bullet == null)
            Debug.Log("!");
        else
        {
            bullet.transform.position = bulletStartPosition.position;
            bullet.transform.Rotate(transform.rotation.eulerAngles);
            bullet.SetActive(true);
        }

    }
}

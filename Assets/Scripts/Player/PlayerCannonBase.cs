using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCannonBase : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private int bulletsCount;

    private WaitForSeconds wait;

    protected BulletsPool bulletsPool;

    private void Start()
    {
        bulletsPool = FindObjectOfType<BulletsPool>();
        bulletsPool.AddBullets(bulletPrefab, bulletsCount);
        wait = new WaitForSeconds(0.15f);
        StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        while (true)
        {
            Shoot();
            yield return wait;
        }
    }

    protected abstract void Shoot();
}

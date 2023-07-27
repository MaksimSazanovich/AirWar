using UnityEngine;

public class PlayerCannonSingle : PlayerCannonBase
{
    [SerializeField] private Transform bulletStartPosition;
    protected override void Shoot()
    {
        var bullet = _bulletsPool.GetObject();
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

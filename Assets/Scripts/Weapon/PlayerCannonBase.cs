using System.Collections;
using UnityEngine;
using Zenject;

public abstract class PlayerCannonBase : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private int _bulletsCount;

    private WaitForSeconds _wait;

    protected BulletsPool _bulletsPool;

    [Inject]
    private void Construct(BulletsPool bulletsPool)
    {
        _bulletsPool = bulletsPool;
    }

    private void Start()
    {
        _bulletsPool.AddObjects(_bulletPrefab, _bulletsCount);
        _wait = new WaitForSeconds(0.15f);
        StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        while (true)
        {
            Shoot();
            yield return _wait;
        }
    }

    protected abstract void Shoot();
}

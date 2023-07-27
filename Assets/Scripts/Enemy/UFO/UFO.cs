using UnityEngine;
using Zenject;

public class UFO : Enemy
{

    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private AudioSource explosionSound;
    [SerializeField] private AudioSource shootSound;
    [SerializeField, Inject] private DiContainer _container;

    private void Start()
    {
        Invoke("Shoot", Random.Range(0.05f, 0.2f));
        
    }


    private void Shoot()
    {
        shootSound.Play();
        //Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
        _container.InstantiatePrefab(enemyBulletPrefab, transform.position, Quaternion.identity, null);
    }
}

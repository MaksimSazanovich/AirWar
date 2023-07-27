using UnityEngine;
using DG.Tweening;
using Zenject;

public class EnemyBulletMove : MonoBehaviour
{
    private Vector3 targetPosition;
    [SerializeField] private float speed;

    private PlayerHealth _playerHealth;

    [Inject]
    private void Construct(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
    }

    private void Start()
    {
        targetPosition = _playerHealth.transform.position;
        transform.DOMove(targetPosition, speed).SetSpeedBased().SetEase(Ease.Linear).OnComplete(() => Destroy(gameObject));
    }
}

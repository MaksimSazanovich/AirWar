using UnityEngine;
using Zenject;

public class EnemyHealth : UnitHealth
{
    private PlayerHealth _playerHealth;
    private EnemyDestruction _enemyDestruction;

    [Inject]
    private void Construct(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
    }

    protected override void Start()
    {
        base.Start();
        _enemyDestruction = GetComponent<EnemyDestruction>();
    }

    private void OnEnable()
    {
        _playerHealth.OnDie += Die;
    }

    private void OnDisable()
    {
        _playerHealth.OnDie -= Die;
    }

    private void OnDestroy()
    {
        _playerHealth.OnDie -= Die;
    }

    public override void Die()
	{        
        transform.rotation = Quaternion.identity;
        _enemyDestruction.Activate();
        base.Die();
    }
}
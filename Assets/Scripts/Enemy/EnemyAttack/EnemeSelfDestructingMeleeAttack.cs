using UnityEngine;

public class EnemeSelfDestructingMeleeAttack : EnemyAttack
{
    private EnemyDestruction _enemyDestruction;

    private void Start()
    {
        _enemyDestruction = GetComponent<EnemyDestruction>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(_damage);
            _enemyDestruction.Activate();
        }
    }
}
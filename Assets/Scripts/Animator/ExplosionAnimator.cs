using UnityEngine;

public class ExplosionAnimator : ObjectAnimator
{
    [SerializeField] private EnemyDestruction _enemyDestruction;

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        _enemyDestruction.OnDie += PlayExplodeAnim;
    }

    private void OnDisable()
    {
        _enemyDestruction.OnDie -= PlayExplodeAnim;
    }

    private void PlayExplodeAnim() => _animator.SetTrigger("Explode");
}
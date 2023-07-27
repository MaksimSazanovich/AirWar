using System;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody;

    protected internal event Action OnDie;
    public void Activate()
    {
        Explode();
    }

    public virtual void Explode()
    {
        OnDie?.Invoke();
        Invoke(nameof(DestroyObject), 1f);
    }

    private void DestroyObject()
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}
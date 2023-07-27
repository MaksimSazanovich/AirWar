using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BulletCollision : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    [SerializeField] private GameObject impactEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(damage);
            //Instantiate(impactEffect, transform.position, transform.rotation);
        }
        ResetObject();
    }

    private void ResetObject()
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        ResetObject();
    }
}

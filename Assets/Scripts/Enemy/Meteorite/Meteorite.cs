using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : Enemy
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Rigidbody2D rigidbody;

    private void Start()
    {
        boxCollider.enabled = true;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    protected override void Move()
    {
        Rigidbody.MovePosition(Rigidbody.position + Speed * Time.fixedDeltaTime * Vector2.down);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Plane plane))
        {
             Destroy(collision.gameObject);
            //plane.ApplyDamage(Damage);
        }
    }

    public override void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            boxCollider.enabled = false;
            rigidbody.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("Explode");
            Invoke("DestroyObject", 1f);
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}

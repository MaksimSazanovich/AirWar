using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : Enemy
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private AudioSource explosionSound;
    private void Start()
    {
        score = 45;
        boxCollider.enabled = true;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    protected override void Move()
    {
        Rigidbody.MovePosition(Rigidbody.position + speed * Time.fixedDeltaTime * Vector2.down);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Plane plane))
        {
            plane.ApplyDamage(damage);
            Explode();
        }
    }



    public override void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            explosionSound.Play();
            Explode();
            FindObjectOfType<ScoreCounter>().AddScore(score);
            FindObjectOfType<DestroyedEnemyCounter>().AddDestroyedNumber("Meteorite");
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void Explode()
    {
        boxCollider.enabled = false;
        rigidbody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Explode");
        Invoke("DestroyObject", 1f);
    }

}

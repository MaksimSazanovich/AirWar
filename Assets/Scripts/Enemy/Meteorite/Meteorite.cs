using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : Enemy
{
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
            Destroy(gameObject);
        }
    }


}

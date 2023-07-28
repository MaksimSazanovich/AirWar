using UnityEngine;

public class HomingMissile : MonoBehaviour
{




    public int Damage;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(Damage);
        }
        gameObject.SetActive(false);
    }

    
}
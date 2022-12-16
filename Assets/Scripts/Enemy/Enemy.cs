using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody2D Rigidbody;
    [SerializeField] protected float Speed = 5f;
    [SerializeField] protected int Damage = 1;
    [SerializeField] protected int health = 5;



    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    protected abstract void Move();

    public abstract void ApplyDamage(int damage);
    
}

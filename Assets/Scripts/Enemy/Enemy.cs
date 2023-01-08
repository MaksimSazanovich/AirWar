using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody2D Rigidbody;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected int damage = 1;
    [SerializeField] protected int health = 5;
    protected int score;

    private Vector3 destroyedPosition = new Vector3(0, -6f, 0);

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        if (transform.position.y <= destroyedPosition.y)
        {
            FindObjectOfType<Plane>().ApplyDamage(damage);
            Destroy(gameObject);
        }
    }

    protected abstract void Move();

    public abstract void ApplyDamage(int damage);
    
    
}

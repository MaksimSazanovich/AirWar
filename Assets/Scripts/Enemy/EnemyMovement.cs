using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    [SerializeField] protected float _speed = 5f;

    private Vector3 destroyedPosition = new Vector3(0, -6f, 0);
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
        if (transform.position.y <= destroyedPosition.y)
        {
            gameObject.SetActive(false);
        }
    }
    private void Move()
    {
        _rigidbody.MovePosition(_rigidbody.position + _speed * Time.fixedDeltaTime * Vector2.down);
    }
}
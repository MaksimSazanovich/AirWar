using UnityEngine;
using Zenject;

public class HomingMissileMovement : MonoBehaviour
{
    Transform target = null;
    private Vector3 targetPosition;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;

    private PlayerHealth _playerHealth;

    [SerializeField] private float offset;

    [Inject]
    private void Construct(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = _playerHealth.transform;

        if (target == null)
        {
            Destroy(gameObject);
            Debug.Log("цель не выбрана");
        }
        if (target != null)
        {
            targetPosition = new Vector3(Random.Range(target.transform.position.x - offset, target.transform.position.x + offset),
            Random.Range(target.transform.position.y - offset, target.transform.position.y + offset), target.transform.position.z);
        }
    }
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
    }

    public void DeactivateHomingMissile() => rotateSpeed = 0;
}
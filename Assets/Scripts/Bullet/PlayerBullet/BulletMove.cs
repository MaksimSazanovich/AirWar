using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMove : MonoBehaviour
{
    [SerializeField] private float speed = 25f;
    [SerializeField] private Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
}

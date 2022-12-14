using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMove : MonoBehaviour
{
    [SerializeField] private float speed = 25f;
    [SerializeField] private Rigidbody2D rigidbody;

    private void FixedUpdate()
    {
        rigidbody.velocity = transform.up * speed;
    }
}

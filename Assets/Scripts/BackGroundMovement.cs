using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.fixedDeltaTime;
    }
}

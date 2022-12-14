using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //[SerializeField] private GameObject impactEffect;
    //[SerializeField] private int damage;
    void Start()
    {
        
    }

    private void Update()
    {

        if (transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}

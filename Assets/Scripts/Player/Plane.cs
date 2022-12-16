using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Plane : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private int health = 3;

    public UnityEvent<int> HealthChanged;

    private void Start()
    {
        HealthChanged.Invoke(health);
    }
    void Update()
    {
        animator.Play("Fly");
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
        HealthChanged.Invoke(health);
        if (health <= 0)
        {
            Time.timeScale = 0;
        }
    }
}

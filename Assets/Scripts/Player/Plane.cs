using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Plane : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private int health = 3;
    [SerializeField] private AudioSource explosionSound;
    private bool isAlive;

    public UnityEvent<int> HealthChanged;
    public UnityEvent OnApplyDamage;
    public UnityEvent Lose;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Start()
    {
        animator.Play("Fly");
        HealthChanged.Invoke(health);
        isAlive = true;
    }
    void Update()
    {
        
        CheckBoundaries();
    }

    public void ApplyDamage(int damage)
    {
        explosionSound.Play();
        health -= damage;
        HealthChanged.Invoke(health);
        OnApplyDamage.Invoke();
        if (health <= 0)
        {          
            isAlive = false;
            Lose.Invoke();
            Time.timeScale = 0;
        }
    }

    private void CheckBoundaries()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));        
        
        if (transform.position.x < -screenBounds.x)
        {
            transform.position = new Vector2(-screenBounds.x, transform.position.y);
        }
        else if (transform.position.x > screenBounds.x)
        {
            transform.position = new Vector2(screenBounds.x, transform.position.y);
        }

        if (transform.position.y < -screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, -screenBounds.y);
        }
        else if (transform.position.y > screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, screenBounds.y);
        }
    }
}

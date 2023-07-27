using UnityEngine;
using UnityEngine.Events;

public class Plane : MonoBehaviour
{
   
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
        HealthChanged.Invoke(health);
        isAlive = true;
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

}

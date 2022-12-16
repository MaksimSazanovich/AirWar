using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private int heath = 3;
    void Update()
    {
        animator.Play("Fly");
    }

    public void ApplyDamage(int damage)
    {
        heath -= damage;
        if (heath <= 0)
        {
            Time.timeScale = 0;
        }
    }
}

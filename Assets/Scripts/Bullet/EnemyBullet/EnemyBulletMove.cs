using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class EnemyBulletMove : MonoBehaviour
{
    private Vector3 targetPosition;
    [SerializeField] private float speed;
    void Start()
    {
        targetPosition = FindObjectOfType<Plane>().transform.position;
        transform.DOMove(targetPosition, speed).SetSpeedBased().SetEase(Ease.Linear).OnComplete(() => Destroy(gameObject));

    }


    void Update()
    {
        
    }
}

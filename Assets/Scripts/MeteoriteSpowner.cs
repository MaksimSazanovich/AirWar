using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpowner : MonoBehaviour
{
    [SerializeField] private GameObject meteoritePrefab;

    [SerializeField] private float timeBetweenSpawns;
    private float nextSpawnTime;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
        //Invoke("SpawnMeteotites", 2f);
        
        }
    }

    private void FixedUpdate()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnMeteotites();
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
    private void SpawnMeteotites()
    {
        Instantiate(meteoritePrefab, SetPosition(), Quaternion.identity );
    }

    private Vector3 SetPosition()
    {
        return new Vector3(Random.Range(-2f, 2f),6f, 0) ;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpowner : MonoBehaviour
{
    [SerializeField] private GameObject meteoritePrefab;
    [SerializeField] private GameObject ufoPrefab;
    private GameObject currentPrefab;

    [SerializeField] private float timeBetweenSpawns;
    private float nextSpawnTime;



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
        int randomNumber = Random.Range(1, 4);
        Debug.Log(randomNumber);
        switch (randomNumber)
        {
            case 1:
                currentPrefab = meteoritePrefab;
                break;
                case 2:
                    currentPrefab = ufoPrefab;
                break;
        }
        Instantiate(currentPrefab, SetPosition(), Quaternion.identity );
    }

    private Vector3 SetPosition()
    {
        return new Vector3(Random.Range(-2f, 2f),6f, 0) ;
    }

    public void ReduceTimeBetweenSpawns()
    {
        timeBetweenSpawns -= 0.05f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnMobs : MonoBehaviour
{
    [Header("SpawnObject")]
    [SerializeField] private Transform[] Point;
    [SerializeField] private GameObject SpawnObject;

    [Header("TimeSpawn")]
    [SerializeField] private float startTimeSpawn;
    private float timeSpawn;

    [Header("SpawnObject")]
    private GameObject[] objects;
    private int objectsInt;
    [SerializeField] private int maxSpawn;

    void Update()
    {
        objectsInt = objects.Length;

        if(objectsInt < maxSpawn && timeSpawn <= 0)
        {
            Instantiate(SpawnObject, Point[Random.Range(0, Point.Length)].position, Quaternion.identity);
            timeSpawn = startTimeSpawn;
        } else
        {
            timeSpawn -= Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // spawner for asteroids
    [SerializeField]
    private float xLimit;
    [SerializeField]
    private float[] xPositions;
    [SerializeField]
    private GameObject[] enemyPrefabs;
    [SerializeField]
    private Wave[] wave;
    
}

[System.Seralizable]
public class Wave
{
    public float delayTime;
    public float spawnAmount;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
     public GameObject Asteroid;
     public Timer timer;
     public float radius = 3.5f; 
     public Transform[] spawnPoint;
     
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine("SpawnRoutine");
    }

    IEnumerator SpawnRoutine()
    {
        while (timer.duration > 0)
        {   
            //Find out what the point on X we can spawn.
            //float x = Random.Range(-radius, radius);
            int index = Random.Range(0, spawnPoint.Length);
            Vector3 pos = spawnPoint[index].position;

            Instantiate(Asteroid, pos, Quaternion.identity);
            yield return new WaitForSeconds (1f);

        }

    
}
}

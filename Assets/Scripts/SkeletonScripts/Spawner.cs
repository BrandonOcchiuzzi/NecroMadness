using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SkeletonPatterns skeleton;
    public float spawnRate = 10.0f;
    public float spawnDistance = 0.25f;
    public int maxSpawnNumber = 3;

    public bool isDying = false;

    public void Start()
    {
        InvokeRepeating(nameof(SpawnSkeleton), this.spawnRate, this.spawnRate);
    }

    private void SpawnSkeleton()
    {

            for (int i = 2; i < this.maxSpawnNumber; i++)
            {
                if(isDying){
                    break;
                }
                //creates a circle with a distance of 0.25 units around the crystal in the middle
                //and sets the spawn point and direction based on that

                Vector3 spawnDirection = Random.insideUnitCircle * this.spawnDistance;
                Vector3 spawnPoint = this.transform.position + spawnDirection;

                Quaternion rotation = Quaternion.identity;

                SkeletonPatterns skeleton = Instantiate(this.skeleton, spawnPoint, rotation);

            }

    }
}

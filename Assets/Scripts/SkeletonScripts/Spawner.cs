using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SkeletonPatterns skeleton;
    public float spawnRate = 10.0f;
    public float spawnDistance = 0.25f;
    public int maxSpawnNumber = 3;
    
    private void Start()
    {
        InvokeRepeating(nameof(SpawnSkeleton), this.spawnRate, this.spawnRate);
    }

    private void SpawnSkeleton()
    {
        /*
        Vector3 centre = this.transform.position;
        
        for (int i = 0; i < this.spawnNumber; i++)
        {
            Vector3 position = RandomCircle(centre, 1.0f);
            Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, centre - position);
            Instantiate(skeleton, position, rotation);
        }

        Vector3 RandomCircle (Vector3 centre, float radius)
        {
            float ang = Random.value * 360;
            Vector3 position;
            position.x = centre.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
            position.y = centre.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
            position.z = centre.z;
            return position;
        }
        */
        for (int i = 2; i < this.maxSpawnNumber; i++)
        {
            //creates a circle with a distance of 0.25 units around the crystal in the middle
            //and sets the spawn point and direction based on that
                        
            Vector3 spawnDirection = Random.insideUnitCircle * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
                        
            Quaternion rotation = Quaternion.identity;
                        
            SkeletonPatterns skeleton = Instantiate(this.skeleton, spawnPoint, rotation);
                        
        }
    }
}

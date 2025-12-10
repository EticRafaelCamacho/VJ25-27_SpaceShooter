using System.Xml.Serialization;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnRate = 1;
    [SerializeField] BoxCollider spawnArea;


    float spawnCooldown = 1;
    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        spawnCooldown -= Time.deltaTime * spawnRate;
        
        if (spawnCooldown <= 0)
        {
            Vector3 spawnPos = GetRandomSpawnInArea();
            Instantiate(enemy,spawnPos, Quaternion.identity);
            spawnCooldown = 1;
        }
    }

    Vector3 GetRandomSpawnInArea()
    {
        // Convert the local size of the collider into world-space extents
        Vector3 size = spawnArea.size;
        Vector3 center = spawnArea.center;

        // Generate random point inside the box (in local space)
        Vector3 randomLocalPos = new Vector3(
            Random.Range(-size.x / 2f, size.x / 2f),
            Random.Range(-size.y / 2f, size.y / 2f),
            0
        );

        // Convert to world space
        return spawnArea.transform.TransformPoint(center + randomLocalPos);
    }
}

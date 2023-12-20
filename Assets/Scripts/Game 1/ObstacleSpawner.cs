using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 2.0f;
    public Transform playerTransform; // Tham chiếu đến vị trí của nhân vật

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            // Tạo chướng ngại vật ở vị trí ngang với nhân vật
            Vector2 spawnPosition = new Vector2(playerTransform.position.x, 6.0f);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            nextSpawnTime = Time.time + 1.0f / spawnRate;
        }
    }
}

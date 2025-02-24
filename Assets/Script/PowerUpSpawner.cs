using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs; // Array power-up yang bisa di-spawn
    public Transform[] spawnPoints; // Spawn points yang bisa di-assign di Inspector
    public float spawnIntervalMin = 3f; // Waktu minimum antar spawn
    public float spawnIntervalMax = 6f; // Waktu maksimum antar spawn

    bool isSpawn = true;

    void Start()
    {
        if (isSpawn)
        {

            // StartCoroutine(SpawnPowerUps());
        }
    }

    public void noSpawn()
    {
        isSpawn = false;
    }
    public void Spawn()
    {
        isSpawn = true;
    }

    IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));

            SpawnPowerUp();
        }
    }

    void SpawnPowerUp()
    {
        if (powerUpPrefabs.Length == 0 || spawnPoints.Length == 0) return;

        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        int randomPowerUpIndex = Random.Range(0, powerUpPrefabs.Length);

        Instantiate(powerUpPrefabs[randomPowerUpIndex], spawnPoints[randomSpawnIndex].position, Quaternion.identity);
    }
}

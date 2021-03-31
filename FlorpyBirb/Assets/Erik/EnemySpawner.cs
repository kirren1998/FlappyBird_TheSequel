using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Settings settings;
    public GameObject enemy;
    [Range(1, 10)] public float spawnSpeed;
    private void Start()
    {
        settings = Settings.settings;
    }
    public void StartGame()
    {
        Invoke("SpawnRock", 3);       
    }
    private void SpawnRock()
    {
        GameObject rock = Instantiate(enemy, new Vector2(transform.position.x, Random.Range(-4.5f, 4.5f)), Quaternion.identity);
        Destroy(rock, 5);
        Invoke("SpawnRock", Random.Range(spawnSpeed / (int)settings.difficulty, 0.1f + spawnSpeed / (int)settings.difficulty));
    }
    
}

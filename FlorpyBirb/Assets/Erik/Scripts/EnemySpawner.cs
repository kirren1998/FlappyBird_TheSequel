using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Settings settings;
    public GameObject enemenemy;
    public Sprite[] rockSprites, tefatSprites, eyeSprites;
    [Range(1, 10)] public float spawnSpeed;
    private void Start()
    {
        settings = Settings.settings;
    }
    public void StartGame()
    {
        Invoke("SpawnDanger", 3);       
    }
    private void SpawnDanger()
    {
        GameObject rock;
        Enemy emily = (Enemy)Random.Range(0, (int)Enemy.maxShit);
        rock = Instantiate(enemenemy, new Vector2(transform.position.x, Random.Range(-4.5f, 4.5f)), Quaternion.identity);
        rock.GetComponent<SpriteRenderer>().sprite = ChangeSprite(emily);
        rock.GetComponent<EnemyFightBack>().enemyType = emily;
        Destroy(rock, 5);
        Invoke("SpawnDanger", Random.Range(spawnSpeed / (int)settings.difficulty, 0.1f + spawnSpeed / (int)settings.difficulty));
    }
    public Sprite ChangeSprite(Enemy emily)
    {
        switch (emily)
        {
            default:
            case Enemy.eye: return eyeSprites[Random.Range(0, eyeSprites.Length)];
            case Enemy.tefat: return tefatSprites[Random.Range(0, tefatSprites.Length)];
            case Enemy.rock: return rockSprites[Random.Range(0, rockSprites.Length)];
        }
    }
    public enum Enemy
    {
        rock,
        tefat,
        eye,
        maxShit,
    }
    /*public GameObject GetSomethingToSpawn(Enemy emily)
    {
        switch (emily)
        {
            default:
            case Enemy.eye:     return eye;
            case Enemy.tefat:   return tefat;
            case Enemy.rock:    return rock;
        }
    }*/
}

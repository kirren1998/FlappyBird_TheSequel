using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int randomAlien;
    Settings settings;
    public GameObject enenemeny;
    public Sprite[] rockSprites, tefatSprites, eyeSprites, alineSprites;
    [Range(0.5f, 1)] public float spawnSpeed;
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
        rock = Instantiate(enenemeny, new Vector2(transform.position.x, Random.Range(-4.5f, 4.5f)), Quaternion.Euler(0, 0, 0));
        rock.GetComponent<SpriteRenderer>().sprite = GibSprite(emily);
        rock.GetComponent<EnemyFightBack>().enemyType = emily;
        rock.GetComponent<EnemyFightBack>().AlienColor = randomAlien;
        if (emily == Enemy.rock || emily == Enemy.tefat) rock.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-1000, 1000);
        Destroy(rock, 5);
        Invoke("SpawnDanger", Random.Range(spawnSpeed / (int)settings.difficulty, 0.1f + spawnSpeed / (int)settings.difficulty));
    }
    public Sprite GibSprite(Enemy emily)
    {
        switch (emily)
        {
            default:
            case Enemy.rock:    return rockSprites[Random.Range(0, rockSprites.Length)];
            case Enemy.alien:
                {
                    randomAlien = Random.Range(0, alineSprites.Length);
                    return alineSprites[randomAlien];
                }
            case Enemy.eye:     return eyeSprites[Random.Range(0, eyeSprites.Length)];
        }   
    }
    public enum Enemy
    {
        alien,
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

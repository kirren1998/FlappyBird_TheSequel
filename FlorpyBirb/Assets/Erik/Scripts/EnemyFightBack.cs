using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFightBack : MonoBehaviour
{
    public int AlienColor;
    public GameObject laser;
    public Sprite[] laserSprites;
    Transform player => GameObject.Find("Player").transform;
    public EnemySpawner.Enemy enemyType;
    // if you hit the rock/enemy with the hand, you get the "GetSlapped" funtion, otherwise you just do the death function
    public void GetSlapped()
    {
        Destroy(gameObject);
    }
    private void Start()
    {
        if (enemyType == EnemySpawner.Enemy.alien) StartCoroutine(SHOOTTHECANONCAPTAIN());
    }

    IEnumerator SHOOTTHECANONCAPTAIN()
    {
        yield return new WaitUntil(() => player.position.x - transform.position.x < 14);
        FireShit();
    }
    void FireShit()
    {
        GameObject lazor = Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 0));
        lazor.GetComponent<SpriteRenderer>().sprite = laserSprites[AlienColor];
        lazor.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        Destroy(lazor, 2);
    }
    private void Update()
    {
        
        switch (enemyType)
        {
            default:
                {
                    Debug.LogError("this path returns nothing");
                    return;
                }
            case EnemySpawner.Enemy.tefat:
                {
                    return;
                }
            case EnemySpawner.Enemy.eye:
                {
                    transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    transform.LookAt(player);
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.x));
                    return;
                }
            case EnemySpawner.Enemy.alien:
                {
                    return;
                }
            case EnemySpawner.Enemy.rock:
                {
                    return;
                }
        }
    }
}

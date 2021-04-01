using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFightBack : MonoBehaviour
{
    Transform player => GameObject.Find("Player").transform;
    public EnemySpawner.Enemy enemyType;
    // if you hit the rock/enemy with the hand, you get the "GetSlapped" funtion, otherwise you just do the death function
    public void GetSlapped()
    {
        Destroy(gameObject);
    }
    private void Update()
    {

        switch (enemyType)
        {
            default:
            case EnemySpawner.Enemy.eye:
                {
                    transform.rotation = Quaternion.Euler(new Vector2(0, transform.position.x - player.position.x));
                    return;
                }
            case EnemySpawner.Enemy.tefat:
                {
                    return;
                }
        }
    }
}

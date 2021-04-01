using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStrikeScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && GetComponentInParent<PlayerMovementScript>().IsAlive == true)
        {
            collision.gameObject.GetComponent<EnemyFightBack>().GetSlapped();
            if (FindObjectOfType<DestroyShitTemp>())
            {
                FindObjectOfType<DestroyShitTemp>().GainPoints(5);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hitPoints;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            hitPoints--;
            if(hitPoints <= 0)
            {
                GameController.instance.KillEnemy();
                Destroy(gameObject);

            }
        }
    }
}

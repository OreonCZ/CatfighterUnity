using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
	float moveSpeed = 7f;
    public Vector2 direction;
    public bool playerHit;
    Enemy enemyScript;

    void Start()
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        enemyScript = enemy.GetComponent<Enemy>(); 
    }
    void Update()
    {
        if(enemyScript.currentEnemyHP > 0) {
        Projectile();
        }
        if(enemyScript.currentEnemyHP <= 0)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 2f);
    }

    void Projectile()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
     void PlayerHit(GameObject Player)
    {
        EnemyProjectileDMG enemyProjectileDMG = Player.GetComponent<EnemyProjectileDMG>();
        if(enemyProjectileDMG != null)
        {
            enemyProjectileDMG.OnHitDamage(1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerHit(collision.gameObject);
            Destroy(gameObject);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
	//float moveSpeed = 7f;
    public Vector2 direction;
    public bool playerHit;
    Enemy enemyScript;
    Movement playerMScript;
    public Enemies enemies;

    void Start()
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        enemyScript = enemy.GetComponent<Enemy>();
        GameObject player = GameObject.FindWithTag("Player");
        playerMScript = player.GetComponent<Movement>();
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
        Destroy(gameObject, enemyScript.destroyProjectile);
    }

    void Projectile()
    {
        transform.Translate(direction * enemyScript.enemyRangeSpeed * Time.deltaTime);
    }
     void PlayerHit(GameObject Player)
    {
        EnemyProjectileDMG enemyProjectileDMG = Player.GetComponent<EnemyProjectileDMG>();
            enemyProjectileDMG.OnHitDamage(enemyScript.enemyRangeDMG);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !playerMScript.isRolling)
        {
            GetComponent<Collider2D>().enabled = true;
            PlayerHit(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && playerMScript.isRolling)
        {
            GetComponent<Collider2D>().enabled = false;
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Sword" && enemyScript.catEnemy2 == enemies.catName)
        {
            Debug.Log("Omg L9");
            Destroy(gameObject);
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscarBulletShoot : MonoBehaviour
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
        if (enemyScript.currentEnemyHP < 15 && enemyScript.currentEnemyHP > 0)
        {
            Projectile();
        }
        if (enemyScript.currentEnemyHP <= 0)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, (enemyScript.destroyProjectile - 2f));
    }

    void Projectile()
    {
        transform.Translate(direction * (enemyScript.enemyRangeSpeed + 6f) * Time.deltaTime);
    }
    void PlayerHit(GameObject Player)
    {
        EnemyProjectileDMG enemyProjectileDMG = Player.GetComponent<EnemyProjectileDMG>();
        enemyProjectileDMG.OnHitDamage(enemyScript.enemyRangeDMG);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !playerMScript.isRolling)
        {
            GetComponent<CircleCollider2D>().enabled = true;
            PlayerHit(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && playerMScript.isRolling)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            return;
        }
    }
}
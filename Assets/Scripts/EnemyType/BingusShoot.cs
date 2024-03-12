using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BingusShoot : MonoBehaviour
{
    //float moveSpeed = 7f;
    public Vector2 direction;
    public bool playerHit;
    Enemy enemyScript;
    Movement playerMScript;
    public Enemies enemies;
    Transform bingusTransform;
    Transform playerTransform;

    void Start()
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        enemyScript = enemy.GetComponent<Enemy>();
        GameObject bingusCat = GameObject.FindWithTag("Enemy");
        bingusTransform = bingusCat.transform;


        GameObject player = GameObject.FindWithTag("Player");
        playerMScript = player.GetComponent<Movement>();
        GameObject playerCat = GameObject.FindWithTag("Player");
        playerTransform = playerCat.transform;

    }
    void Update()
    {
        if (enemyScript.currentEnemyHP > 0)
        {
            Projectile();
        }
        if (enemyScript.currentEnemyHP <= 0)
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
        if (collision.gameObject.tag == "Player" && !playerMScript.isRolling)
        {
            GetComponent<Collider2D>().enabled = true;
            transform.position = new Vector2(transform.position.x, transform.position.y);
            PlayerHit(collision.gameObject);
            Destroy(gameObject);
            if (enemyScript.bingusSecond) {
            bingusTransform.transform.position = new Vector2(playerTransform.transform.position.x, playerTransform.transform.position.y + 1);
            }
        }
        else if (collision.gameObject.tag == "Player" && playerMScript.isRolling)
        {
            GetComponent<Collider2D>().enabled = false;
            return;
        }
    }
}
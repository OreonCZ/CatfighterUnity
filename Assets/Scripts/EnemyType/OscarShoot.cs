using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscarShoot : MonoBehaviour
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

        GameObject player = GameObject.FindWithTag("Player");
        playerMScript = player.GetComponent<Movement>();

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject);
            return;
        }
    }
}
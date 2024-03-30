using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruchaShoot : MonoBehaviour
{
    //float moveSpeed = 7f;
    public Vector2 direction;
    public bool playerHit;
    Enemy enemyScript;
    Movement playerMScript;
    public Enemies enemies;
    Transform bruchaTransform;
    Transform playerTransform;

    void Start()
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        enemyScript = enemy.GetComponent<Enemy>();
        GameObject bruchaCat = GameObject.FindWithTag("Enemy");
        bruchaTransform = bruchaCat.transform;

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
        if (enemyScript.currentEnemyHP <= 15 && enemyScript.currentEnemyHP > 10)
        {

        }
        Destroy(gameObject, enemyScript.destroyProjectile);
    }

    void Projectile()
    {
        transform.Translate(direction * enemyScript.enemyRangeSpeed * Time.deltaTime);
    }
    /*
    void PlayerHit(GameObject Player)
    {
        EnemyProjectileDMG enemyProjectileDMG = Player.GetComponent<EnemyProjectileDMG>();
        enemyProjectileDMG.OnHitDamage(enemyScript.enemyRangeDMG);
    }
    */
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Collider2D>().enabled = true;
            transform.position = new Vector2(transform.position.x, transform.position.y);
            //PlayerHit(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
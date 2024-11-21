using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;


public class EnemySoldierShoot : MonoBehaviour
{
    //float moveSpeed = 7f;
    public Vector2 direction;
    public bool playerHit;
    EnemySoldier enemyScript;
    EnemySoldierHP enemySoldierHP;
    Movement playerMScript;
    public Enemies enemies;
    Parry parry;
    GameObject player;

    void Start()
    {
        //enemyScript = GetComponent<EnemySoldier>();
        //enemySoldierHP = GetComponent<EnemySoldierHP>();
        player = GameObject.FindWithTag(ObjectTags.Player.ToString());
        GameObject enemy = GameObject.FindWithTag(ObjectTags.Enemy.ToString());
        playerMScript = player.GetComponent<Movement>();
        enemyScript = enemy.GetComponent<EnemySoldier>();
        enemySoldierHP = enemy.GetComponent<EnemySoldierHP>();
        parry = player.GetComponent<Parry>();

    }
    void Update()
    {
        if (enemySoldierHP.currentSoldierHp > 0)
        {
            Projectile();
        }
        if (enemySoldierHP.currentSoldierHp <= 0)
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()) && parry.isParrying)
        {
            Destroy(gameObject);
            return;
        }
        if (collision.CompareTag(ObjectTags.Player.ToString()) && !playerMScript.isRolling || !parry.isParrying)
        {
            //GetComponent<CircleCollider2D>().enabled = true;
            PlayerHit(collision.gameObject);
            Destroy(gameObject);
            return;
        }
        if (collision.CompareTag(ObjectTags.Player.ToString()) && playerMScript.isRolling)
        {
            //GetComponent<CircleCollider2D>().enabled = false;
            return;
        }
    }
}


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
    EnemyRangerAttack enemyRangerAttack;
    EnemyBulletAttack enemyBulletAttack;
    [HideInInspector] public GameObject enemy;


    void Start()
    {
        //enemyScript = GetComponent<EnemySoldier>();
        //enemySoldierHP = GetComponent<EnemySoldierHP>();
        player = GameObject.FindWithTag(ObjectTags.Player.ToString());
        playerMScript = player.GetComponent<Movement>();
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

    public void EnemyInitialization(GameObject enemy)
    {
        enemyScript = enemy.GetComponent<EnemySoldier>();
        enemySoldierHP = enemy.GetComponent<EnemySoldierHP>();
        if("Ranger" == enemyScript.catName)
        {
            enemyRangerAttack = enemy.GetComponent<EnemyRangerAttack>();
        }
        if ("Fiend" == enemyScript.catName)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
        }
        if ("Intruder" == enemyScript.catName)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
        }
        if ("Cultist" == enemyScript.catName)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
        }
        if ("Ninja" == enemyScript.catName)
        {
            enemyRangerAttack = enemy.GetComponent<EnemyRangerAttack>();
        }
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

    void EnemyTriggerOutcomes(Collider2D collision)
    {
        if ("Cultist" == enemyScript.catName)
        {
            Destroy(gameObject);
        }

        else
        {
            if (parry.isParrying)
            {
                Destroy(gameObject);
            }
            else if (!playerMScript.isRolling && !parry.isParrying)
            {
                //GetComponent<CircleCollider2D>().enabled = true;
                PlayerHit(collision.gameObject);
                Debug.Log(collision.name);
                Destroy(gameObject);
            }
            else if (playerMScript.isRolling)
            {
                //GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()))
        {
            EnemyTriggerOutcomes(collision);
            return;
        }
        if (collision.CompareTag(ObjectTags.Sword.ToString())){
        
            if ("Ninja" == enemyScript.catName)
            {
                Destroy(gameObject);
            }
            return;
        }
    }
}




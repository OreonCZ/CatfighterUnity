using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;


public class EnemyIntruderShoot : MonoBehaviour
{
    //float moveSpeed = 7f;
    public Vector2 direction;
    public bool playerHit;
    EnemySoldier enemyScript;
    EnemySoldierHP enemySoldierHP;
    EnemyHP enemyHP;
    Movement playerMScript;
    public Enemies enemies;
    Parry parry;
    GameObject player;
    EnemyRangerAttack enemyRangerAttack;
    EnemyBulletAttack enemyBulletAttack;
    [HideInInspector] public GameObject enemy;
    ParticleSystem particleSpawn;
    HpBar hpBar;


    void Start()
    {
        //enemyScript = GetComponent<EnemySoldier>();
        //enemySoldierHP = GetComponent<EnemySoldierHP>();
        player = GameObject.FindWithTag(ObjectTags.Player.ToString());
        playerMScript = player.GetComponent<Movement>();
        parry = player.GetComponent<Parry>();
        hpBar = player.GetComponent<HpBar>();
        

    }
    void Update()
    {
        CatCompare();
        //Debug.Log(enemyScript.catName);
    }

    public void EnemyInitialization(GameObject enemy)
    {
        enemyScript = enemy.GetComponent<EnemySoldier>();
        if("Intruder" == enemyScript.catName)
        {
            enemySoldierHP = enemy.GetComponent<EnemySoldierHP>();
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
        }
        if("Bingus" == enemyScript.catName)
        {
            enemyHP = enemy.GetComponent<EnemyHP>();
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
        }
    }

    void CatCompare()
    {
        if("Bingus" == enemyScript.catName)
        {
            if (enemyHP.currentSoldierHp > 0)
            {
                Projectile();
            }
            if (enemyHP.currentSoldierHp <= 0)
            {
                Destroy(gameObject);
            }
        }

        else
        {
            if (enemySoldierHP.currentSoldierHp > 0)
            {
                Projectile();
            }
            if (enemySoldierHP.currentSoldierHp <= 0)
            {
                Destroy(gameObject);
            }
        }
        Destroy(gameObject, enemyScript.destroyProjectile);
    }

    void Projectile()
    {
            transform.Translate(direction * enemyScript.enemyRangeSpeed * Time.deltaTime);
    }

    void DealRangedDamage(float damage)
    {
        hpBar.currentHp -= damage;
    }
    /*void PlayerHit(GameObject Player)
    {
        EnemyProjectileDMG enemyProjectileDMG = Player.GetComponent<EnemyProjectileDMG>();
        enemyProjectileDMG.OnHitDamage(enemyScript.enemyRangeDMG);
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()))
        {
            DealRangedDamage(enemyScript.enemyRangeDMG);
            float angle = Random.Range(0f, 360f);
            particleSpawn = enemy.GetComponentInChildren<ParticleSystem>();
            enemy.transform.position = Quaternion.Euler(0f, 0f, angle) * new Vector2(1, 0) + new Vector3(player.transform.position.x, player.transform.position.y);
            particleSpawn.Play();
            Destroy(gameObject);
            return;
        }
        if (collision.CompareTag(ObjectTags.Sword.ToString()))
        {
            if ("Bingus" == enemyScript.catName)
            {
                Destroy(gameObject);
            }
            return;
        }
    }
}


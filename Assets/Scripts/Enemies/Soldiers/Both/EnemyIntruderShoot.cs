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
    Movement playerMScript;
    public Enemies enemies;
    Parry parry;
    GameObject player;
    EnemyRangerAttack enemyRangerAttack;
    EnemyBulletAttack enemyBulletAttack;
    [HideInInspector] public GameObject enemy;
    ParticleSystem particleSpawn;


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
        if("Intruder" == enemyScript.catName)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
        }
    }

    void Projectile()
    {
            transform.Translate(direction * enemyScript.enemyRangeSpeed * Time.deltaTime);
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
            float angle = Random.Range(0f, 360f);
            particleSpawn = enemy.GetComponentInChildren<ParticleSystem>();
            enemy.transform.position = Quaternion.Euler(0f, 0f, angle) * new Vector2(1, 0) + new Vector3(player.transform.position.x, player.transform.position.y);
            particleSpawn.Play();
            Destroy(gameObject);
            return;
        }
    }
}


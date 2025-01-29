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
    flowerHP flowerHP;
    EnemyHP enemyHP;
    Movement playerMScript;
    public Enemies enemies;
    Parry parry;
    GameObject player;
    EnemyRangerAttack enemyRangerAttack;
    EnemyBulletAttack enemyBulletAttack;
    [HideInInspector] public GameObject enemy;
    public bool bruchaBulletTouched;
    PlayerStats playerStats;


    void Start()
    {
        //enemyScript = GetComponent<EnemySoldier>();
        //enemySoldierHP = GetComponent<EnemySoldierHP>();
        player = GameObject.FindWithTag(ObjectTags.Player.ToString());
        playerMScript = player.GetComponent<Movement>();
        parry = player.GetComponent<Parry>();
        playerStats = player.GetComponent<PlayerStats>();

    }
    void Update()
    {
        DiffEnemyRanger();
    }

    void DiffEnemyRanger()
    {
        if(enemies.isBoss && !enemies.isMelee)
        {
            if (enemyHP.currentSoldierHp > 0)
            {
                Projectile();
            }
            if (enemyHP.currentSoldierHp <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(gameObject, enemyScript.destroyProjectile);
        }

        else if(!enemies.isBoss && !enemies.isMelee && !enemies.isTurret)
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
        else if(enemies.isTurret)
        {
            if (flowerHP.currentSoldierHp > 0)
            {
                Projectile();
            }
            if (flowerHP.currentSoldierHp <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(gameObject, enemyScript.destroyProjectile);
        }
    }

    public void EnemyInitialization(GameObject enemy)
    {
        enemyScript = enemy.GetComponent<EnemySoldier>();
        if (enemies.isRanger)
        {
            enemyRangerAttack = enemy.GetComponent<EnemyRangerAttack>();
            enemySoldierHP = enemy.GetComponent<EnemySoldierHP>();
        }
        else if (enemies.isBoss && !enemies.isMelee)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
            enemyHP = enemy.GetComponent<EnemyHP>();
        }
        else if(enemies.isTurret)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
            flowerHP = enemy.GetComponent<flowerHP>();
        }
        else
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
            enemySoldierHP = enemy.GetComponent<EnemySoldierHP>();
        }
    }

    void Projectile()
    {
        if (enemies.catName == "Oscar" || enemies.catName == "Luna"){
            return;
        }
        else {
            transform.Translate(direction * enemyScript.enemyRangeSpeed * Time.deltaTime);
        } 
    }
    void PlayerHit(GameObject Player)
    {
        EnemyProjectileDMG enemyProjectileDMG = Player.GetComponent<EnemyProjectileDMG>();
        enemyProjectileDMG.OnHitDamage(enemyScript.enemyRangeDMG);
        if ("Lucik" == enemyScript.catName)
        {
            Lucik lucik = GameObject.Find("Lucik").GetComponent<Lucik>();
            lucik.barValue += enemyScript.enemyRangeDMG;
        }
    }

    IEnumerator BruchaParry()
    { 
        Debug.Log("BruchaParry started");
        Brucha.bulletTouchedPlayer = true;
        yield return new WaitForSeconds(1f);
        Brucha.bulletTouchedPlayer = false;
        Debug.Log("BruchaParry ended");
        Destroy(gameObject);
    }

    IEnumerator DestoyAfterTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void EnemyTriggerOutcomes(Collider2D collision)
    {
        if ("Cultist" == enemyScript.catName || "Oscar" == enemyScript.catName)
        {
            Destroy(gameObject);
        }
        else if ("Luna" == enemyScript.catName)
        {
            if (!playerMScript.isRolling)
            {
                PlayerHit(collision.gameObject);
                Destroy(gameObject);
            }
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
                //Debug.Log(collision.name);
                Destroy(gameObject);
            }
            else if (playerMScript.isRolling)
            {
                //GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()))
        {
            if ("Brucha" == enemyScript.catName)
            {
                StartCoroutine(BruchaParry());
            }
        }
    }
}




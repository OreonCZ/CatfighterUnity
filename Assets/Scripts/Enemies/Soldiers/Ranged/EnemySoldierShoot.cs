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
    EnemyHP enemyHP;
    Movement playerMScript;
    public Enemies enemies;
    Parry parry;
    GameObject player;
    EnemyRangerAttack enemyRangerAttack;
    EnemyBulletAttack enemyBulletAttack;
    [HideInInspector] public GameObject enemy;
    public bool bruchaBulletTouched;


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
        DiffEnemyRanger();
    }

    void DiffEnemyRanger()
    {
        if(enemyScript.catName == "Yuki" || enemyScript.catName == "Bingus" || enemyScript.catName == "Miscar" || enemyScript.catName == "Oscar" || enemyScript.catName == "Brucha")
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
            Destroy(gameObject, enemyScript.destroyProjectile);
        }
    }

    public void EnemyInitialization(GameObject enemy)
    {
        enemyScript = enemy.GetComponent<EnemySoldier>();
        if("Ranger" == enemyScript.catName)
        {
            enemyRangerAttack = enemy.GetComponent<EnemyRangerAttack>();
            enemySoldierHP = enemy.GetComponent<EnemySoldierHP>();
        }
        if ("Fiend" == enemyScript.catName)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
            enemySoldierHP = enemy.GetComponent<EnemySoldierHP>();
        }
        if ("Intruder" == enemyScript.catName)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
            enemySoldierHP = enemy.GetComponent<EnemySoldierHP>();
        }
        if ("Cultist" == enemyScript.catName)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
            enemySoldierHP = enemy.GetComponent<EnemySoldierHP>();
        }
        if ("Ninja" == enemyScript.catName)
        {
            enemyRangerAttack = enemy.GetComponent<EnemyRangerAttack>();
            enemySoldierHP = enemy.GetComponent<EnemySoldierHP>();
        }
        if ("Yuki" == enemyScript.catName)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
            enemyHP = enemy.GetComponent<EnemyHP>(); 
        }
        if ("Bingus" == enemyScript.catName)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
            enemyHP = enemy.GetComponent<EnemyHP>();
        }
        if ("Miscar" == enemyScript.catName)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
            enemyHP = enemy.GetComponent<EnemyHP>();
        }
        if ("Oscar" == enemyScript.catName)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
            enemyHP = enemy.GetComponent<EnemyHP>();
        }
        if ("Brucha" == enemyScript.catName)
        {
            enemyBulletAttack = enemy.GetComponent<EnemyBulletAttack>();
            enemyHP = enemy.GetComponent<EnemyHP>();
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

    IEnumerator BruchaParry()
    {
        Debug.Log("BruchaParry started");
        bruchaBulletTouched = true;
        yield return new WaitForSeconds(1f);
        bruchaBulletTouched = false;
        Debug.Log("BruchaParry ended");
    }

    void EnemyTriggerOutcomes(Collider2D collision)
    {
        if ("Cultist" == enemyScript.catName || "Oscar" == enemyScript.catName)
        {
            Destroy(gameObject);
        }
        else if ("Brucha" == enemyScript.catName)
        {
            if (bruchaBulletTouched)
            {
                Debug.Log("BruchaParry already active. Skipping...");
                return;
            }
            StartCoroutine(BruchaParry());
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
                //Debug.Log(collision.name);
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




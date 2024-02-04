using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakingDmgPlayer : MonoBehaviour
{
    public HpBar hpbar;
    public Enemies enemies;
    public Enemy enemy;
    public EnemyMovement enemyMovement;
    public Movement playerMovement;
    public Animator animator;
    public bool enemyTakeDmg = false;
    public bool enemyDamageToPL = true;
    public bool enemyStop = false;
    public float enemySlow = 0f;
    public float enemyStun = 0.5f;
    float enemyAttackCool;

    void Start()
    {
        enemyAttackCool = enemies.enemyAttackCooldown;
    }

    void Update()
    {
        if (enemyTakeDmg && enemyDamageToPL)
        {
            StartCoroutine(DealDamage());
           // StartCoroutine(EnemyStop());
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!playerMovement.isRolling && !enemy.enemyDed) {
                enemyTakeDmg = true;
                Debug.Log("dmg bool: " + enemyTakeDmg);
                enemyMovement.enemyMovementSpeed = enemySlow;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        enemyTakeDmg = false;
        enemyMovement.enemyMovementSpeed = enemies.enemySpeed;
    }

    IEnumerator EnemyStop()
    {
        enemyMovement.enemyMovementSpeed = enemySlow;
        yield return new WaitForSeconds(enemyStun);
        enemyMovement.enemyMovementSpeed = enemies.enemySpeed;
    }
    IEnumerator DealDamage()
    {
         enemyDamageToPL = false;
         hpbar.currentHp -= enemies.enemyDamage;
         Debug.Log("Zivoty: " + hpbar.currentHp);
         yield return new WaitForSeconds(enemyAttackCool);
         enemyDamageToPL = true;
    }
}

    

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
    float enemyNormalSpeed;

    void Start()
    {
        enemyAttackCool = enemies.enemyAttackCooldown;
        enemyNormalSpeed = enemy.enemyMovementSpeed;
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
            if (!playerMovement.isRolling)
            {
                if (!enemy.enemyDed)
                {
                    enemyTakeDmg = true;
                }
                else if (enemy.enemyDed)
                {
                    enemyTakeDmg = false;
                }
                enemy.enemyMovementSpeed = enemySlow;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        enemyTakeDmg = false;
        enemy.enemyMovementSpeed = enemyNormalSpeed;
    }

    IEnumerator DealDamage()
    {
         enemyDamageToPL = false;
         hpbar.currentHp -= enemy.enemyDMG;
         yield return new WaitForSeconds(enemyAttackCool);
         enemyDamageToPL = true;
    }
}

    

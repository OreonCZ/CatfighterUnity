using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakingDmgPlayer : MonoBehaviour
{
    public HpBar hpbar;
    public Enemies enemies;
    public EnemyMovement enemyMovement;
    public Movement playerMovement;
    public Animator animator;
    public float enemySlow = 0f;
    public float enemyStun = 0.5f;
    float enemyAttackCool;

    void Start()
    {
        enemyAttackCool = Time.time + enemies.enemyAttackCooldown;
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (!playerMovement.isRolling) { 
                StartCoroutine(DealDamage());
                }
            StartCoroutine(EnemyStop());
        }

        IEnumerator EnemyStop()
        {
            enemyMovement.StopAnimations();
            enemyMovement.enemyMovementSpeed = enemySlow;
            yield return new WaitForSeconds(enemyStun);
            enemyMovement.enemyMovementSpeed = enemies.enemySpeed;
            enemyMovement.OnAnimations();
        }
        IEnumerator DealDamage()
        {
            hpbar.currentHp -= enemies.enemyDamage;
            yield return new WaitForSeconds(enemyAttackCool);
            
        }
    }
}

    

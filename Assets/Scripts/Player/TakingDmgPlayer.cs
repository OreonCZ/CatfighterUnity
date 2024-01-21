using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakingDmgPlayer : MonoBehaviour
{
    public HpBar hpbar;
    public Enemies enemy;
    public EnemyMovement enemyMovement;
    public float enemySlow = 0f;
    public float enemyStun = 0.5f;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hpbar.currentHp -= enemy.enemyDamage;
           
            StartCoroutine(EnemyStop());

        }

        IEnumerator EnemyStop()
        {
            enemyMovement.enemyMovementSpeed = enemySlow;
            yield return new WaitForSeconds(enemyStun);
            enemyMovement.enemyMovementSpeed = enemy.enemySpeed;
        }
    }
}

    

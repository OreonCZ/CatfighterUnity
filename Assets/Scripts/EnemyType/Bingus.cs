using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bingus : MonoBehaviour
{
    EnemyHP enemyHP;
    public Enemies enemies;
    public GameObject speedUp;
    CircleCollider2D circleCollider;
    EnemySoldier enemySoldier;

    // Start is called before the first frame update
    void Start()
    {
        enemyHP = GetComponent<EnemyHP>();
        circleCollider = speedUp.GetComponent<CircleCollider2D>();
        enemySoldier = GetComponent<EnemySoldier>();
    }
    
    void Update()
    {
        if(enemies.maxEnemyHp * 0.1f < enemyHP.currentSoldierHp && enemies.maxEnemyHp / 2 >= enemyHP.currentSoldierHp)
        {
            enemySoldier.enemyRangeSpeed = 14f;
        }
        else if(enemyHP.currentSoldierHp <= enemies.maxEnemyHp * 0.1f)
        {
            enemySoldier.enemyDMG = 2f;
            enemySoldier.fireRate = 1f;
            circleCollider.radius = 0;
        }
    }
}

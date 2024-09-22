using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier : MonoBehaviour
{
    public Enemies enemies;
    public float enemyMovementSpeed;
    public int maxEnemyHP;
    public int enemyRangeDMG;
    public float enemyRangeSpeed;
    public float enemyAttackCooldown;
    public int enemyDMG;
    public float destroyProjectile;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        enemyMovementSpeed = enemies.enemySpeed;
        maxEnemyHP = enemies.maxEnemyHp;
        //slider.maxValue = maxEnemyHP;
        //currentEnemyHP = maxEnemyHP;
        //slider.value = currentEnemyHP;
        enemyRangeDMG = enemies.shootDamage;
        enemyRangeSpeed = enemies.fireSpeed;
        enemyDMG = enemies.enemyDamage;
        enemyAttackCooldown = enemies.enemyAttackCooldown;
        destroyProjectile = enemies.destroyProjectile;
        fireRate = enemies.fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

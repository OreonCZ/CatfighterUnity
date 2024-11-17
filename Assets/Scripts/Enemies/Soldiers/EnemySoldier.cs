using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier : MonoBehaviour
{
    public Enemies enemies;
    [HideInInspector] public float enemyMovementSpeed;
    [HideInInspector] public float maxEnemyHP;
    [HideInInspector] public float enemyRangeDMG;
    [HideInInspector] public float enemyRangeSpeed;
    [HideInInspector] public float enemyAttackCooldown;
    [HideInInspector] public float enemyDMG;
    [HideInInspector] public float destroyProjectile;
    [HideInInspector] public float fireRate;
    // Start is called before the first frame update
    void Awake()
    {
        enemyMovementSpeed = enemies.enemySpeed;
        maxEnemyHP = enemies.maxEnemyHp;
        //slider.maxValue = maxEnemyHP;
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

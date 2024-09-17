using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier : MonoBehaviour
{
    public Enemies enemies;
    public float enemyMovementSpeed;
    public float enemyMovementSpeedOriginal;
    public int maxEnemyHP;
    public int enemyRangeDMG;
    public float enemyRangeSpeed;
    public int enemyDMG;
    public float destroyProjectile;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        enemyMovementSpeed = enemies.enemySpeed;
        enemyMovementSpeedOriginal = enemyMovementSpeed;
        maxEnemyHP = enemies.maxEnemyHp;
        //slider.maxValue = maxEnemyHP;
        //currentEnemyHP = maxEnemyHP;
        //slider.value = currentEnemyHP;
        enemyRangeDMG = enemies.shootDamage;
        enemyRangeSpeed = enemies.fireSpeed;
        enemyDMG = enemies.enemyDamage;
        destroyProjectile = enemies.destroyProjectile;
        fireRate = enemies.fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier : MonoBehaviour
{
    public Enemies enemies;
    public Animator animator;
    [HideInInspector] public string catName;
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
        catName = enemies.catName;
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

    private enum CatNames
    {
        Knight, Ranger
    }
    public void EnemyNameCompare()
    {
        if (CatNames.Knight.ToString() == catName)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("FightRight", false);
            animator.SetBool("FightLeft", false);
        }
        if (CatNames.Ranger.ToString() == catName)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Fight", false);
        }
    }

    public void EnemyAttackDiff(EnemySoldierAttack enemySoldierAttack, EnemyRangerAttack enemyRangerAttack)
    {
        if (CatNames.Knight.ToString() == catName)
        {
            enemySoldierAttack = GetComponentInChildren<EnemySoldierAttack>();
        }
        if (CatNames.Ranger.ToString() == catName)
        {
            enemyRangerAttack = GetComponentInChildren<EnemyRangerAttack>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
    [HideInInspector] public int catLvl;
    [HideInInspector] public bool isBoss;
    [HideInInspector] public bool isRanger;
    [HideInInspector] public bool isMelee;
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
        catLvl = enemies.catLevel;
        isBoss = enemies.isBoss;
        isRanger = enemies.isRanger;
        isMelee = enemies.isMelee;
    }

    public enum CatNames
    {
        Knight, Ranger, Fiend, Intruder, Cultist, Ninja, Kevin, Yuki, Bingus, Miscar, Oscar, Brucha, FBingus
    }
    public void EnemyNameCompare()
    {
        if (!enemies.isRanger)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("FightRight", false);
            animator.SetBool("FightLeft", false);
        }
        else
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Fight", false);
        }
    }

    public void EnemyAttackDiff(EnemySoldierAttack enemySoldierAttack, EnemyRangerAttack enemyRangerAttack, EnemyBulletAttack enemyBulletAttack)
    {
        if (enemies.isMelee)
        {
            enemySoldierAttack = GetComponentInChildren<EnemySoldierAttack>();
        }
        else if (!enemies.isMelee && enemies.isRanger)
        {
            enemyRangerAttack = GetComponentInChildren<EnemyRangerAttack>();
        }
        else
        {
            enemySoldierAttack = GetComponentInChildren<EnemySoldierAttack>();
            enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

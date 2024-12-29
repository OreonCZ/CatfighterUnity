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
    }

    public enum CatNames
    {
        Knight, Ranger, Fiend, Intruder, Cultist, Ninja, Kevin, Yuki, Bingus, Miscar, Oscar, Brucha
    }
    public void EnemyNameCompare()
    {
        if (CatNames.Knight.ToString() == catName)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("FightRight", false);
            animator.SetBool("FightLeft", false);
        }
        if (CatNames.Fiend.ToString() == catName)
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
        if (CatNames.Intruder.ToString() == catName)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("FightRight", false);
            animator.SetBool("FightLeft", false);
        }
        if (CatNames.Cultist.ToString() == catName)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("FightRight", false);
            animator.SetBool("FightLeft", false);
        }
        if (CatNames.Ninja.ToString() == catName)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Fight", false);
        }
        if (CatNames.Kevin.ToString() == catName)
        {
            animator.SetBool("FightRight", false);
            animator.SetBool("FightLeft", false);
        }
        if (CatNames.Yuki.ToString() == catName)
        {
            animator.SetBool("FightRight", false);
            animator.SetBool("FightLeft", false);
        }
        if (CatNames.Bingus.ToString() == catName)
        {
            animator.SetBool("FightRight", false);
            animator.SetBool("FightLeft", false);
        }
        if (CatNames.Miscar.ToString() == catName)
        {
            animator.SetBool("FightRight", false);
            animator.SetBool("FightLeft", false);
        }
        if (CatNames.Oscar.ToString() == catName)
        {
            animator.SetBool("FightRight", false);
            animator.SetBool("FightLeft", false);
        }
        if (CatNames.Brucha.ToString() == catName)
        {
            animator.SetBool("FightRight", false);
            animator.SetBool("FightLeft", false);
        }
    }

    public void EnemyAttackDiff(EnemySoldierAttack enemySoldierAttack, EnemyRangerAttack enemyRangerAttack, EnemyBulletAttack enemyBulletAttack)
    {
        if (CatNames.Knight.ToString() == catName)
        {
            enemySoldierAttack = GetComponentInChildren<EnemySoldierAttack>();
        }
        if (CatNames.Fiend.ToString() == catName)
        {
            enemySoldierAttack = GetComponentInChildren<EnemySoldierAttack>();
            enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
        }
        if (CatNames.Ranger.ToString() == catName)
        {
            enemyRangerAttack = GetComponentInChildren<EnemyRangerAttack>();
        }
        if (CatNames.Intruder.ToString() == catName)
        {
            enemySoldierAttack = GetComponentInChildren<EnemySoldierAttack>();
            enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
        }
        if (CatNames.Cultist.ToString() == catName)
        {
            enemySoldierAttack = GetComponentInChildren<EnemySoldierAttack>();
            enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
        }
        if (CatNames.Ninja.ToString() == catName)
        {
            enemyRangerAttack = GetComponentInChildren<EnemyRangerAttack>();
        }
        if (CatNames.Kevin.ToString() == catName)
        {
            enemySoldierAttack = GetComponentInChildren<EnemySoldierAttack>();
        }
        if (CatNames.Yuki.ToString() == catName)
        {
            enemySoldierAttack = GetComponentInChildren<EnemySoldierAttack>();
            enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
        }
        if (CatNames.Bingus.ToString() == catName)
        {
            enemySoldierAttack = GetComponentInChildren<EnemySoldierAttack>();
            enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
        }
        if (CatNames.Miscar.ToString() == catName)
        {
            enemySoldierAttack = GetComponentInChildren<EnemySoldierAttack>();
            enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
        }
        if (CatNames.Oscar.ToString() == catName)
        {
            enemySoldierAttack = GetComponentInChildren<EnemySoldierAttack>();
            enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
        }
        if (CatNames.Brucha.ToString() == catName)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;
using UnityEngine.UI;

public class EnemySoldierHP : MonoBehaviour
{
    EnemySoldier enemySoldier;
    [HideInInspector] public EnemySoldierAttack enemySoldierAttack;
    [HideInInspector] public EnemyRangerAttack enemyRangerAttack;
    [HideInInspector] public EnemyBulletAttack enemyBulletAttack;
    [HideInInspector] public GameObject enemyHpBar;
    [HideInInspector] public Slider enemyHpSlider;
    [HideInInspector] public float currentSoldierHp;
    EnemySoldierMoving enemySoldierMoving;
    Animator animator;
    public static bool isDefeated = false;
    bool isKilled = false;
    GameObject player;
    PlayerStats playerStats;

    // Start is called before the first frame update

    void Start()
    {
        enemySoldier = GetComponent<EnemySoldier>();
        animator = GetComponent<Animator>();
        enemySoldierMoving = GetComponent<EnemySoldierMoving>();
        //Debug.Log(currentSoldierHp + " " + enemySoldier.maxEnemyHP);
        enemyHpBar = transform.Find("EnemyBar").gameObject;
        enemyHpSlider = enemyHpBar.GetComponentInChildren<Slider>();
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        playerStats = player.GetComponent<PlayerStats>();

        currentSoldierHp = enemySoldier.maxEnemyHP;

        enemySoldier.EnemyAttackDiff(enemySoldierAttack, enemyRangerAttack, enemyBulletAttack);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHpSlider != null)
        {
            enemyHpSlider.value = currentSoldierHp;
        }
        if (currentSoldierHp <= 0)
        {
            DiffCat();
            isDefeated = true;
            isKilled = true;

            enemySoldierMoving.agent.isStopped = true;
            enemySoldierMoving.isFollowing = false;
            animator.SetBool("Ko", true);
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingRight", false);
            enemySoldier.EnemyNameCompare();
            enemyHpBar.SetActive(false);
        }
    }

    void GetMoneyOnce(int value)
    {
        if(!isKilled) playerStats.IncreaseMoney(value * enemySoldier.catLvl);
    }

    private void DiffCat()
    {
        if ("Knight" == enemySoldier.catName)
        {
            enemySoldierAttack.soldierCanAttack = false;
            enemySoldierAttack.soldierAttacks = false;
            GetMoneyOnce(2);
        }
        if ("Fiend" == enemySoldier.catName)
        {
            enemySoldierAttack.soldierCanAttack = false;
            enemySoldierAttack.soldierAttacks = false;
            GetMoneyOnce(4);
        }
        if ("Ranger" == enemySoldier.catName)
        {
            //enemyRangerAttack.soldierAttacks = false;
            //enemyRangerAttack.soldierCanAttack = false;
            GetMoneyOnce(1);
        }
        if ("Intruder" == enemySoldier.catName)
        {
            enemySoldierAttack.soldierAttacks = false;
            enemySoldierAttack.soldierCanAttack = false;
            GetMoneyOnce(5);
        }
    }
}


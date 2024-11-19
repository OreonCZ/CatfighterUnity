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
    [HideInInspector] public GameObject enemyHpBar;
    [HideInInspector] public Slider enemyHpSlider;
    [HideInInspector] public float currentSoldierHp;
    EnemySoldierMoving enemySoldierMoving;
    Animator animator;
    public static bool isDefeated = false;

    // Start is called before the first frame update

    void Start()
    {
        enemySoldier = GetComponent<EnemySoldier>();
        animator = GetComponent<Animator>();
        enemySoldierMoving = GetComponent<EnemySoldierMoving>();
        Debug.Log(currentSoldierHp + " " + enemySoldier.maxEnemyHP);
        enemyHpBar = transform.Find("EnemyBar").gameObject;
        enemyHpSlider = enemyHpBar.GetComponentInChildren<Slider>();

        currentSoldierHp = enemySoldier.maxEnemyHP;

        enemySoldier.EnemyAttackDiff(enemySoldierAttack, enemyRangerAttack);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentSoldierHp + " " + enemySoldier.maxEnemyHP);
        if (enemyHpSlider != null)
        {
            enemyHpSlider.value = currentSoldierHp;
        }
        //Debug.Log(currentSoldierHp);
        if (currentSoldierHp <= 0)
        {
            DiffCat();
            enemySoldierMoving.agent.isStopped = true;
            enemySoldierMoving.isFollowing = false;
            isDefeated = true;
            animator.SetBool("Ko", true);
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingRight", false);
            enemySoldier.EnemyNameCompare();
            enemyHpBar.SetActive(false);
        }
    }
    private void DiffCat()
    {
        if("Knight" == enemySoldier.catName)
        {
            enemySoldierAttack.soldierCanAttack = false;
            enemySoldierAttack.soldierAttacks = false;
        }
        if("Ranger" == enemySoldier.catName)
        {
            //enemyRangerAttack.soldierAttacks = false;
            //enemyRangerAttack.soldierCanAttack = false;
        }
    }
}


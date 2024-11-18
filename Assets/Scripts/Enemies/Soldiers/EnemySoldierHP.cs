using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;
using UnityEngine.UI;

public class EnemySoldierHP : MonoBehaviour
{
    EnemySoldier enemySoldier;
    public EnemySoldierAttack enemySoldierAttack;
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
            enemySoldierAttack.soldierCanAttack = false;
            enemySoldierAttack.soldierAttacks = false;
            enemySoldierMoving.agent.isStopped = true;
            isDefeated = true;
            animator.SetBool("Ko", true);
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingRight", false);
            enemySoldier.EnemyNameCompare();
        }
    }
}
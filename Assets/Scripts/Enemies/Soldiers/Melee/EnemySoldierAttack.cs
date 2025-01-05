using Assets.Scripts.EnumTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldierAttack : MonoBehaviour
{
    public GameObject enemy;
    EnemyHP enemyHP;
    GameObject player;
    GameObject parentSoldierGameObject;
    EnemySoldierMoving parentSoldier;
    EnemySoldier parentSoldierStats;
    HpBar playerHpBar;
    Movement playerMovement;
    Parry playerParry;
    SpriteRenderer spriteRenderer;
    public bool soldierCanAttack = true;
    [HideInInspector] public bool isTouchingPlayer = false;
    public bool soldierAttacks = false;
    private float chargeSoldierBar = 0f;
    Animator animator;
    Brucha brucha;

    private Coroutine colorChangeCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        parentSoldier = gameObject.transform.parent.gameObject.GetComponent<EnemySoldierMoving>();
        parentSoldierStats = gameObject.transform.parent.gameObject.GetComponent<EnemySoldier>();
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        playerHpBar = player.GetComponent<HpBar>();
        playerMovement = player.GetComponent<Movement>();
        playerParry = player.GetComponent<Parry>();
        animator = gameObject.transform.parent.gameObject.GetComponent<Animator>();
        spriteRenderer = enemy.GetComponent<SpriteRenderer>();
        enemyHP = enemy.GetComponent<EnemyHP>();
        brucha = enemy.GetComponent<Brucha>();
        //animator = gameObject.transform.parent.gameObject.GetComponent<Animator>();
    }

    void AttackCooldown()
    {
        if (!soldierCanAttack)
        {
            chargeSoldierBar = Mathf.Lerp(chargeSoldierBar, chargeSoldierBar + 1f, Time.deltaTime / parentSoldierStats.enemyAttackCooldown);
            if(chargeSoldierBar >= 1f)
            {
                chargeSoldierBar = 0f;
                soldierCanAttack = true;
            }
        }

    }
    void DealDamage()
    {
        if (soldierCanAttack && soldierAttacks && !playerMovement.isRolling)
        {
            soldierCanAttack = false;
            if (!playerParry.isParrying)
            {
                playerHpBar.currentHp -= parentSoldierStats.enemyDMG;
                if(parentSoldierStats.catName == "Brucha" && brucha.transformBrucha)
                {
                    enemyHP.currentSoldierHp += (parentSoldierStats.enemyDMG / 4);
                }
                Debug.Log("au");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()))
        {
            parentSoldier.isFollowing = false;
            soldierAttacks = true;
            isTouchingPlayer = true;
            animator.SetBool("Idle", false);
            if (parentSoldier.agent.velocity.x > 0)
            {
                animator.SetBool("FightRight", true);
                animator.SetBool("FightLeft", false);
            }
            if (parentSoldier.agent.velocity.x < 0)
            {
                animator.SetBool("FightRight", false);
                animator.SetBool("FightLeft", true);
            }
            if (!playerParry.isParrying && !playerMovement.isRolling)
            {
                DealDamage();   
            }
            //soldierCanAttack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()))
        {
            parentSoldier.isFollowing = true;
            soldierAttacks = false;
            isTouchingPlayer = false;
            animator.SetBool("FightRight", false);
            animator.SetBool("FightLeft", false);
            //soldierCanAttack = false;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        AttackCooldown();
        DealDamage();
        //Debug.Log(chargeSoldierBar);
    }
}



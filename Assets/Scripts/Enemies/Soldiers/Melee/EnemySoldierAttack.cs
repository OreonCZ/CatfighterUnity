using Assets.Scripts.EnumTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldierAttack : MonoBehaviour
{
    GameObject player;
    EnemySoldierMoving parentSoldier;
    EnemySoldier parentSoldierStats;
    HpBar playerHpBar;
    Movement playerMovement;
    Parry playerParry;
    public bool soldierCanAttack = true;
    [HideInInspector] public bool isTouchingPlayer = false;
    public bool soldierAttacks = false;
    private float chargeSoldierBar = 0f;
    Animator animator;

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
                //Debug.Log("au");
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

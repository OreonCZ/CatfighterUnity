using Assets.Scripts.EnumTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletAttack : MonoBehaviour
{
    GameObject player;
    EnemySoldierMoving parentSoldier;
    EnemySoldier parentSoldierStats;
    //HpBar playerHpBar;
    Movement playerMovement;
    Parry playerParry;
    public bool soldierCanAttack = true;
    public bool canShoot = true;
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
        //playerHpBar = player.GetComponent<HpBar>();
        //playerMovement = player.GetComponent<Movement>();
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
        //Debug.Log("bludimir");
        /*
        if (soldierCanAttack && soldierAttacks && !playerMovement.isRolling)
        {
            soldierCanAttack = false;
            if (!playerParry.isParrying)
            {
                playerHpBar.currentHp -= parentSoldierStats.enemyDMG;
                //Debug.Log("au");
            }
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()))
        {
            soldierAttacks = true;
            isTouchingPlayer = true;
            animator.SetBool("Idle", false);
            canShoot = true;
            //animator.SetBool("Fight", true);
            
            //DealDamage();
         
            soldierCanAttack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()))
        {
            soldierAttacks = false;
            isTouchingPlayer = false;
            //animator.SetBool("Fight", false);
            soldierCanAttack = false;
            canShoot = false;
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

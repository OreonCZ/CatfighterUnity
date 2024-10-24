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
    public bool soldierCanAttack = true;
    public bool soldierAttacks = false;
    public float chargeSoldierBar = 0f;

    // Start is called before the first frame update
    void Start()
    {
        parentSoldier = gameObject.transform.parent.gameObject.GetComponent<EnemySoldierMoving>();
        parentSoldierStats = gameObject.transform.parent.gameObject.GetComponent<EnemySoldier>();
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        playerHpBar = player.GetComponent<HpBar>();
        playerMovement = player.GetComponent<Movement>();
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
            playerHpBar.currentHp -= parentSoldierStats.enemyDMG;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()))
        {
            parentSoldier.isFollowing = false;
            soldierAttacks = true;
            //soldierCanAttack = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()))
        {
            parentSoldier.isFollowing = true;
            soldierAttacks = false;
            //soldierCanAttack = false;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        DealDamage();
        AttackCooldown();
    }
}

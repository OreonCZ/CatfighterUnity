using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.EnumTypes;

public class TakingDMG : MonoBehaviour
{
    [HideInInspector] public bool isKilled = false;
    Fight fight;
    GameObject swordRadius;
    //EnemySoldierHP enemySoldierHp;
    GameObject enemySoldier;
    GameObject player;

    void Start()
    {
        swordRadius = GameObject.FindWithTag(ObjectTags.Sword.ToString());
        enemySoldier = GameObject.FindGameObjectWithTag(ObjectTags.Enemy.ToString());
        //enemySoldierHp = enemySoldier.GetComponent<EnemySoldierHP>();
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        fight = player.GetComponent<Fight>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(ObjectTags.Enemy.ToString()) || collider.CompareTag(ObjectTags.Fiend.ToString()) || collider.CompareTag(ObjectTags.flower.ToString()))
        {
            Debug.Log("enemy hit");
            EnemySoldierHP enemySoldierHp = collider.gameObject.GetComponent<EnemySoldierHP>();
            EnemyHP enemyHP = collider.gameObject.GetComponent<EnemyHP>();
            flowerHP flowerHP = collider.gameObject.GetComponent<flowerHP>();
            if (enemySoldierHp != null)
            {
                enemySoldierHp.currentSoldierHp -= fight.attackDamage;
                Debug.Log(enemySoldierHp.currentSoldierHp);
                swordRadius.SetActive(false);
            }
            if (enemyHP != null)
            {
                enemyHP.currentSoldierHp -= fight.attackDamage;
                Debug.Log(enemyHP.currentSoldierHp);
                swordRadius.SetActive(false);
                if(enemyHP.currentSoldierHp <= 0 && enemyHP.isDefeated)
                {
                    enemyHP.isKilled = true;
                }

            }
            if (flowerHP != null)
            {
                flowerHP.currentSoldierHp -= fight.attackDamage;
                swordRadius.SetActive(false);

            }
        }
    }
}
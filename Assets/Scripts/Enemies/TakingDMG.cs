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
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        fight = player.GetComponent<Fight>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            EnemySoldierHP enemySoldierHp = collider.gameObject.GetComponent<EnemySoldierHP>();
            if (enemySoldierHp != null)
            {
                enemySoldierHp.currentSoldierHp -= fight.attackDamage;
                swordRadius.SetActive(false);
            }
        }
    }
}


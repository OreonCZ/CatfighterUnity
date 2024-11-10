using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class Parry : MonoBehaviour
{
    Fight playerFight;
    GameObject enemyCollider;
    PlayerStats catStats;
    Movement playerMovement;
    Animator catAnimations;
    EnemySoldierAttack enemySoldierAttack;
    [HideInInspector] public bool isParrying = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyCollider = GameObject.FindGameObjectWithTag(ObjectTags.KnightCollider.ToString());

        playerFight = gameObject.GetComponent<Fight>();
        playerMovement = gameObject.GetComponent<Movement>();
        catAnimations = gameObject.GetComponent<Animator>();
        catStats = gameObject.GetComponent<PlayerStats>();

        enemySoldierAttack = enemyCollider.GetComponent<EnemySoldierAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        CatParry();
        //Debug.Log(isParrying);
    }

    void CatParry() {
        bool canParry = Input.GetKeyDown(KeyCode.Q) && !playerFight.isFighting && !playerMovement.isMoving;
        if (canParry || isParrying)
        {
            if (!isParrying)
            {
                catAnimations.SetTrigger("ParryWait");
                StartCoroutine(ParryTimer(0.7f));
            }
            playerMovement.canRoll = false;
            playerFight.canAttack = false;
            if (enemySoldierAttack.isTouchingPlayer)
            {
                playerMovement.canWalk = true;
                playerMovement.movementSpeed = catStats.playerMovementSpeed;
            }
            else
            {
                playerMovement.canWalk = false;
                playerMovement.movementSpeed = 0f;
            }
        }

    }

    IEnumerator ParryTimer(float seconds)
    {
        isParrying = true;
        yield return new WaitForSeconds(seconds);
        isParrying = false;
        playerMovement.canWalk = true;
        playerFight.canAttack = true;
        playerMovement.canRoll = true;
        playerMovement.movementSpeed = catStats.playerMovementSpeed;
    }

    /*IEnumerator Idle(float seconds)
    {
        playerMovement.canWalk = false;
        playerMovement.canRoll = false;
        playerFight.canAttack = false;
        isParrying = true;
        playerMovement.movementSpeed = 0f;
        catAnimations.SetTrigger("ParryWait");
        yield return new WaitForSeconds(seconds);
        playerMovement.canWalk = true;
        playerFight.canAttack = true;
        playerMovement.canRoll = true;
        isParrying = false;
        playerMovement.movementSpeed = catStats.playerMovementSpeed;
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.KnightCollider.ToString()))
        {
            StartCoroutine(ParryTimer(0.7f));
            //Debug.Log("kolize");
            if (enemySoldierAttack.isTouchingPlayer && isParrying) catAnimations.SetTrigger("CatParry");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.KnightCollider.ToString()))
        {
            isParrying = false;
        }
    }
}

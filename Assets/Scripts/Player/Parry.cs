using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class Parry : MonoBehaviour
{
    Fight playerFight;
    PlayerStats catStats;
    Movement playerMovement;
    Animator catAnimations;
    [HideInInspector] public bool isParrying = false;
    [HideInInspector] public bool canParry = true;
    [HideInInspector] public float parryBar = 0f;
    private List<EnemySoldierAttack> activeEnemies = new List<EnemySoldierAttack>();

    void Start()
    {
        playerFight = gameObject.GetComponent<Fight>();
        playerMovement = gameObject.GetComponent<Movement>();
        catAnimations = gameObject.GetComponent<Animator>();
        catStats = gameObject.GetComponent<PlayerStats>();
    }

    void Update()
    {
        Debug.Log(canParry);
        parryBar = Mathf.Lerp(parryBar, parryBar + 1f, Time.deltaTime);
        if (parryBar >= 1f)
        {
            parryBar = 1f;
            CatParry();
        } 
    }

    void CatParry()
    {
        bool parry = Input.GetKeyDown(KeyCode.Q) && !playerFight.isFighting && !playerMovement.isMoving;
        if (parry && canParry)
        {
            parryBar = 0f;
            if (!isParrying)
            {
                StartCoroutine(ParryTimer(0.5f));
            }
            playerMovement.canRoll = false;
            if (activeEnemies.Exists(enemy => enemy.isTouchingPlayer))
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
        catAnimations.SetBool("ParryWait", true);
        isParrying = true;
        playerFight.canAttack = false;
        yield return new WaitForSeconds(seconds);
        isParrying = false;
        playerMovement.canWalk = true;
        playerFight.canAttack = true;
        playerMovement.canRoll = true;
        playerMovement.movementSpeed = catStats.playerMovementSpeed;
        catAnimations.SetBool("ParryWait", false);
    }

    IEnumerator ParrySpark(float seconds)
    {
        playerMovement.canWalk = true;
        playerMovement.movementSpeed = catStats.playerMovementSpeed;
        catAnimations.SetBool("ParryWait", false);
        catAnimations.SetBool("CatParry", true);
        yield return new WaitForSeconds(seconds);
        catAnimations.SetBool("CatParry", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.KnightCollider.ToString()))
        {
            EnemySoldierAttack enemy = collision.GetComponent<EnemySoldierAttack>();
            if (enemy != null && !activeEnemies.Contains(enemy))
            {
                activeEnemies.Add(enemy);
                if (isParrying)
                {
                    StartCoroutine(ParrySpark(0.5f));
                }
                canParry = false;
            }
        }
        if (collision.CompareTag(ObjectTags.Bullet.ToString())){
            if (isParrying)
            {
                StartCoroutine(ParrySpark(0.5f));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.KnightCollider.ToString()))
        {
            EnemySoldierAttack enemy = collision.GetComponent<EnemySoldierAttack>();
            if (enemy != null)
            {
                activeEnemies.Remove(enemy);
            }

            if (activeEnemies.Count == 0)
            {
                canParry = true;
            }
        }
    }
}



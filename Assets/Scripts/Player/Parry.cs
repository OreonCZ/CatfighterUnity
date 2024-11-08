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
    public bool isParrying = false;
    // Start is called before the first frame update
    void Start()
    {
        playerFight = gameObject.GetComponent<Fight>();
        playerMovement = gameObject.GetComponent<Movement>();
        catAnimations = gameObject.GetComponent<Animator>();
        catStats = gameObject.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        CatParry();
    }

    void CatParry() {
        if(Input.GetKeyDown(KeyCode.Q) && !playerFight.isFighting && !playerMovement.isMoving)
        {
            StartCoroutine(Idle(0.7f));
        }
    }

    IEnumerator Idle(float seconds)
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.KnightCollider.ToString()) && isParrying)
        {
            Debug.Log("kolize");
            catAnimations.SetTrigger("CatParry");
            playerMovement.canWalk = true;
            playerMovement.canRoll = true;
            isParrying = false;
            playerMovement.movementSpeed = catStats.playerMovementSpeed;
        }
    }
}

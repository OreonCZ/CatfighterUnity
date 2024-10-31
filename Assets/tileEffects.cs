using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class tileEffects : MonoBehaviour
{
    public float slowDown;
    GameObject player;
    PlayerStats playerStats;
    HpBar playerHp;
    Movement playerMovement;
    private bool canDealPoison;
    private float poisonBar = 0;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        playerStats = player.GetComponent<PlayerStats>();
        playerHp = player.GetComponent<HpBar>();
        animator = gameObject.GetComponent<Animator>();
        playerMovement = player.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canDealPoison)
        {
            PoisonEffect();
        }
    }

    private void PoisonEffect() {
        poisonBar += 1f * Time.deltaTime;
            if (poisonBar >= 1f)
            {
                poisonBar = 0f;
                playerHp.currentHp -= 1;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()) && gameObject.CompareTag(ObjectTags.mud.ToString()))
        {
            playerMovement.movementSpeed = playerStats.playerMovementSpeed - slowDown;
        }
        if (collision.CompareTag(ObjectTags.Player.ToString()) && gameObject.CompareTag(ObjectTags.poison.ToString()))
        {
            canDealPoison = true;
            playerMovement.movementSpeed = playerStats.playerMovementSpeed - slowDown;
        }
        if (collision.CompareTag(ObjectTags.Player.ToString()) && gameObject.CompareTag(ObjectTags.fartShroom.ToString()))
        {
            if (Random.Range(0, 10) < 2)
            {
                playerHp.currentHp -= playerStats.playerMaxHP * 0.2f;
                animator.SetTrigger("isTouched");
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()) && gameObject.CompareTag(ObjectTags.mud.ToString()))
        {
            playerMovement.movementSpeed = playerStats.playerMovementSpeed;
        }
        if (collision.CompareTag(ObjectTags.Player.ToString()) && gameObject.CompareTag(ObjectTags.poison.ToString()))
        {
            canDealPoison = false;
            playerMovement.movementSpeed = playerStats.playerMovementSpeed;
        }
    }
}

    


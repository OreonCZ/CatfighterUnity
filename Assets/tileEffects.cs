using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class tileEffects : MonoBehaviour
{
    public float slowDown;
    GameObject player;
    PlayerStats playerStats;
    Movement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        playerStats = player.GetComponent<PlayerStats>();
        playerMovement = player.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()) && gameObject.tag == "mud")
        {
            playerMovement.movementSpeed = playerStats.playerMovementSpeed/2;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()) && gameObject.tag == "mud")
        {
            playerMovement.movementSpeed = playerStats.playerMovementSpeed;
        }
    }
}

    


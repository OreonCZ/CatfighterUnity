using Assets.Scripts.EnumTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySoldierMoving : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    GameObject player;
    Vector3 directionToPlayer;
    EnemySoldier enemySoldier;
    public bool isFollowing;
    CircleCollider2D circleCollider;
    public float radiusChange = 1;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        enemySoldier = GetComponent<EnemySoldier>();
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
    }
    void MovementEnemy()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        enemyRb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * enemySoldier.enemyMovementSpeed;
        //Debug.Log("pome");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isFollowing) MovementEnemy();
        else
        {
            enemyRb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isFollowing && collision.gameObject.tag == ObjectTags.Player.ToString()){ 

            isFollowing = true;
            circleCollider.radius += radiusChange;
            Debug.Log("Started following");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isFollowing && collision.gameObject.tag == ObjectTags.Player.ToString()) {
            isFollowing = false;
            circleCollider.radius -= radiusChange;
            Debug.Log("Stopped following");
        }
    }

}

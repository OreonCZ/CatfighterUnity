using Assets.Scripts.EnumTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemySoldierMoving : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    SpriteRenderer spriteRenderer;
    GameObject player;
    Vector3 directionToPlayer;
    EnemySoldier enemySoldier;
    SpriteRenderer enemySprite;
    SpriteRenderer playerSprite;
    public bool isFollowing;
    CircleCollider2D circleCollider;
    public float radiusChange = 1;
    public Animator animator;
    [HideInInspector] public EnemyBulletAttack enemyBulletAttack;
    [HideInInspector] public EnemySoldierAttack enemySoldierAttack;
    [HideInInspector] public EnemyRangerAttack enemyRangerAttack;

    //[SerializeField] Transform target;

    [HideInInspector] public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        enemySoldier = GetComponent<EnemySoldier>();
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        enemySprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();


        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        enemySoldier.EnemyAttackDiff(enemySoldierAttack, enemyRangerAttack, enemyBulletAttack);
    }

    void MovementEnemy()
    {
        enemySoldier.EnemyNameCompare();

        agent.speed = enemySoldier.enemyMovementSpeed;
        
        //directionToPlayer = (player.transform.position - transform.position);
        //enemyRb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y);

        if(enemySoldier.catName == "FBingus")
        {
            Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
            agent.SetDestination(targetPosition);
        }
        else agent.SetDestination(player.transform.position);

        agent.isStopped = false;

        if(agent.velocity.x > 0)
        {
            animator.SetBool("WalkingRight", true);
            animator.SetBool("WalkingLeft", false);
        }
        if(agent.velocity.x < 0)
        {
            animator.SetBool("WalkingRight", false);
            animator.SetBool("WalkingLeft", true);
        }
        //Debug.Log("pome");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(agent.destination);
        if (isFollowing) MovementEnemy();
        else
        {
            //enemyRb.velocity = Vector2.zero;
            agent.isStopped = true;
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingRight", false);
        }
        OrderSortingLayers();
    }

    private void OrderSortingLayers()
    {
        double playerY, enemyY;
        playerY = playerSprite.bounds.min.y;
        enemyY = enemySprite.bounds.min.y;
        if(playerY > enemyY)
        {
            enemySprite.sortingOrder = 1;
        }
        else
        {
            enemySprite.sortingOrder = -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString())){ 
            if("Fiend" == enemySoldier.catName)
            {
                EnemyBulletAttack enemyBulletAttacks = GetComponentInChildren<EnemyBulletAttack>();
                enemyBulletAttacks.canShoot = false;
                //enemyBulletAttack.canShoot = false;
                Debug.Log("ejakfhnsishnvgkjsen");
            }
            animator.SetBool("Idle", false);
            isFollowing = true;
            circleCollider.radius += radiusChange;
            //Debug.Log("Started following");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString())) {
            if ("Fiend" == enemySoldier.catName)
            {
                EnemyBulletAttack enemyBulletAttacks = GetComponentInChildren<EnemyBulletAttack>();
                enemyBulletAttacks.canShoot = true;
            }
            isFollowing = false;
            animator.SetBool("Idle", true);
            circleCollider.radius -= radiusChange;
            //Debug.Log("Stopped following");
        }
    }

}

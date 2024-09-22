using Assets.Scripts.EnumTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemySoldierMoving : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    GameObject player;
    Vector3 directionToPlayer;
    EnemySoldier enemySoldier;
    public bool isFollowing;
    CircleCollider2D circleCollider;
    public float radiusChange = 1;

    [SerializeField] Transform target;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        enemySoldier = GetComponent<EnemySoldier>();
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }
    void MovementEnemy()
    {
        agent.speed = enemySoldier.enemyMovementSpeed;
        // directionToPlayer = (player.transform.position - transform.position).normalized;
        //enemyRb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * enemySoldier.enemyMovementSpeed;
        agent.SetDestination(target.position);
        agent.isStopped = false;
        //Debug.Log("pome");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFollowing) MovementEnemy();
        else
        {
            //enemyRb.velocity = Vector2.zero;
            agent.isStopped = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isFollowing && collision.CompareTag(ObjectTags.Player.ToString())){ 

            isFollowing = true;
            circleCollider.radius += radiusChange;
            Debug.Log("Started following");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isFollowing && collision.CompareTag(ObjectTags.Player.ToString())) {
            isFollowing = false;
            circleCollider.radius -= radiusChange;
            Debug.Log("Stopped following");
        }
    }

}

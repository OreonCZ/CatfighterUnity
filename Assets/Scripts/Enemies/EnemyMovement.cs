using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    public Enemies enemy;
    public GameObject player;
    public Animator animator;
    public TakingDmgPlayer takingDmgPlayer;
    private Vector3 localScale;
    private Vector3 directionToPlayer;
    public float enemyMovementSpeed;
    public bool enemyCanMove;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        enemyMovementSpeed = enemy.enemySpeed;
    }
    
    public void MovementEnemy()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        enemyRb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * enemyMovementSpeed;

}
    // Update is called once per frame
    void FixedUpdate()
    {
    if (enemyCanMove)
    {
        MovementEnemy();
    }
    }

    private void LateUpdate()
    {
        if (enemyCanMove) { 
            if(enemyRb.velocity.x > 0)
            {
                if (!takingDmgPlayer.enemyTakeDmg) { 
                MovingRight();
                }
                else if (takingDmgPlayer.enemyTakeDmg)
                {
                    FightRight();
                }
            }
            if (enemyRb.velocity.x < 0)
            {
                if (!takingDmgPlayer.enemyTakeDmg)
                {
                    MovingLeft();
                }
                else if (takingDmgPlayer.enemyTakeDmg)
                {
                    FightLeft();
                }
            }
        }
    }
    void MovingLeft()
    {
        animator.SetBool("isHit", false);
        animator.SetBool("WalkingLeft", true);
        animator.SetBool("WalkingRight", false);
    }
    void MovingRight()
    {
        animator.SetBool("isHit", false);
        animator.SetBool("WalkingRight", true);
        animator.SetBool("WalkingLeft", false);
    }

    void FightLeft()
    {
        animator.SetBool("isHit", true);
        animator.SetBool("WalkingLeft", true);
        animator.SetBool("WalkingRight", false);
    }
    void FightRight()
    {
        animator.SetBool("isHit", true);
        animator.SetBool("WalkingRight", true);
        animator.SetBool("WalkingLeft", false);
    }

}

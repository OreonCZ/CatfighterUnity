using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    public Enemies enemy;
    public Enemy enemyObject;
    public GameObject player;
    public Animator animator;
    public TakingDmgPlayer takingDmgPlayer;
    public TakingDMG takingDmgEnemy1;
    public TakingDMG takingDmgEnemy2;
    public TakingDMG takingDmgEnemy3;
    public TakingDMG takingDmgEnemy4;
    private Vector3 localScale;
    public Vector3 directionToPlayer;
    public float enemyMovementSpeed;
    public bool enemyCanMove;
    public new AudioSource audio;
    public AudioClip music;
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
            if (enemyObject.enemyDed)
            {
                animator.SetBool("isDefeated", true);
                enemyMovementSpeed = 0;
                if (takingDmgEnemy1.isKilled || takingDmgEnemy2.isKilled || takingDmgEnemy3.isKilled || takingDmgEnemy4.isKilled)
                {
                    animator.SetBool("isDefeated", false);
                    animator.SetBool("isKilled", true);
                    audio.clip = music;
                    audio.Stop();
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

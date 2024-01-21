using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    public Enemies enemy;
    public GameObject player;
    private Vector3 localScale;
    private Vector3 directionToPlayer;
    public float enemyMovementSpeed;
    public bool enemyCanMove = true;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        enemyMovementSpeed = enemy.enemySpeed;
    }

    
    public void MovementEnemy()
    {
        if (enemyCanMove)
        {
            directionToPlayer = (player.transform.position - transform.position).normalized;
        enemyRb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * enemyMovementSpeed;
    }
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
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
        if (enemyRb.velocity.x < 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
        }
    }
}

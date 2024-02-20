using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuki : MonoBehaviour
{
    public Enemy enemy;
    public EnemyMovement enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.currentEnemyHP <= 4)
        {
            enemyMovement.enemyMovementSpeed = 1f;
            enemy.destroyProjectile = 6f;
            enemy.enemyRangeSpeed = 5f;
            enemy.fireRate = 10f;
        }
    }
}

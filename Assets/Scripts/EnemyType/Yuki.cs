using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuki : MonoBehaviour
{
    public Enemy enemy;
    public EnemyMovement enemyMovement;
    TakingDmgPlayer takingDMGPlayer;
    // Start is called before the first frame update
    void Start()
    {
        takingDMGPlayer = gameObject.GetComponent<TakingDmgPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.currentEnemyHP <= 4)
        {
            if (!takingDMGPlayer.enemyTakeDmg)
            {
                enemy.enemyMovementSpeed = 2f;
            }
            enemy.destroyProjectile = 6f;
            enemy.enemyRangeSpeed = 5f;
            enemy.fireRate = 8f;
        }
    }
}

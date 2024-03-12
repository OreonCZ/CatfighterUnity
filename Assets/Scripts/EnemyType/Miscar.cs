using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miscar : MonoBehaviour
{
    public Enemy enemy;
    public EnemyBulletScript enemyBullet;
    TakingDmgPlayer takingDMGPlayer;
    // Start is called before the first frame update
    void Start()
    {
        takingDMGPlayer = gameObject.GetComponent<TakingDmgPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.currentEnemyHP <= 5)
        {
            if (!takingDMGPlayer.enemyTakeDmg)
            {
                enemy.enemyMovementSpeed = 3f;
            }
            enemy.destroyProjectile = 20f;
            enemy.enemyRangeSpeed = 0f;
            enemy.enemyRangeDMG = 2;
            enemy.fireRate = 2f;
            enemyBullet.projectile.transform.localScale = new Vector3(1f, 1f, 1f);

        }
        if (enemy.currentEnemyHP > 5)
        {
            enemyBullet.projectile.transform.localScale = new Vector3(3f, 3f, 3f);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuki : MonoBehaviour
{
    public Enemy enemy;
    public EnemyMovement enemyMovement;
    public bool yukiShoot = false;
    public bool canShoot = true;
    public Enemies enemies;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        YukiChange();
        
    }

    void YukiChange()
    {
        if ( enemy.currentEnemyHP <= (enemies.maxEnemyHp / 2) && enemy.currentEnemyHP > 1)
        {
            enemy.destroyProjectile = 2f;
            enemy.enemyRangeSpeed = 8f;
            enemy.fireRate = 10f;
            StartCoroutine(YukiCooldown());
        }
        else if(enemy.currentEnemyHP == 1)
        {
            enemy.enemyRangeSpeed = 10f;
            enemy.fireRate = 20f;
            StartCoroutine(YukiCooldown());
        }
    }

    IEnumerator YukiCooldown()
    {
        if (yukiShoot)
        {
            canShoot = true;
            animator.SetBool("isReloading", false);
            enemy.enemyMovementSpeed = 3f;
            yield return new WaitForSeconds(1.5f);
            yukiShoot = false;
        }
        else if (!yukiShoot)
        {
            canShoot = false;
            animator.SetBool("isReloading", true);
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingRight", false);
            enemy.enemyMovementSpeed = 0f;
            yield return new WaitForSeconds(1.5f);
            yukiShoot = true;
        }
    }
}

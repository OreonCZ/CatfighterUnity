using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuki : MonoBehaviour
{
    EnemySoldier enemy;
    EnemyHP enemyHP;
    EnemySoldierMoving enemyMovement;
    public bool yukiShoot = false;
    public bool canShoot = true;
    bool yukiTransform = false;
    public EnemySoldierBullet enemySoldierBullet;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemySoldier>();
        enemyHP = GetComponent<EnemyHP>();
        enemyMovement = GetComponent<EnemySoldierMoving>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        YukiChange();
        
    }

    void YukiChange()
    {
        if ( enemyHP.currentSoldierHp <= (enemy.maxEnemyHP / 2) && enemyHP.currentSoldierHp > 1)
        {
            enemy.destroyProjectile = 2f;
            enemy.enemyRangeSpeed = 8f;
            enemy.fireRate = 10f;
            StartCoroutine(WaitYuki());
            StartCoroutine(YukiCooldown());
        }
        else if( enemyHP.currentSoldierHp == 1)
        {
            enemy.enemyRangeSpeed = 10f;
            enemy.fireRate = 20f;
            StartCoroutine(YukiCooldown());
        }
        else if ( enemyHP.currentSoldierHp == 0)
        {
            animator.SetBool("isReloading", false);
        }
    }

    IEnumerator WaitYuki()
    {
        if (!yukiTransform) {

        yield return new WaitForSeconds(1.5f);

        yukiTransform = true;
        }
    }
        IEnumerator YukiCooldown()
    {
        if (yukiShoot)
        {
            enemySoldierBullet.wait = true;
            canShoot = true;
            animator.SetBool("isReloading", false);
            enemyMovement.isFollowing = true;
            yield return new WaitForSeconds(1.5f);
            yukiShoot = false;
        }
        else if (!yukiShoot)
        {
            enemySoldierBullet.wait = false;
            canShoot = false;
            animator.SetBool("isReloading", true);
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingRight", false);
            enemyMovement.isFollowing = false;
            yield return new WaitForSeconds(1.5f);
            yukiShoot = true;
        }
    }
}

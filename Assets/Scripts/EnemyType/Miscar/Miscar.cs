using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miscar : MonoBehaviour
{
    public Enemy enemy;
    public MiscarBulletScript enemyBullet;
    public GameObject projectileMiscar;
    public Transform playerPosition;
    public int random;
    public Animator animator;
    public bool changeMiscar = true;
    bool cooldownMiscar = false;
    public Enemies enemies;
    public GameObject miscarObject;
    public Vector2 direction;
    bool lastHp = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MiscarChange();
        direction = (playerPosition.position - transform.position).normalized;
        enemyBullet.projectile.transform.Translate(direction * enemy.enemyRangeSpeed * Time.deltaTime);
    }

    void MiscarChange()
    {
        if (1 < enemy.currentEnemyHP && enemy.currentEnemyHP <= (enemies.maxEnemyHp / 2))
        {
            ChangeSkill();
            
            if(!changeMiscar)
            {
                enemy.destroyProjectile = 5f;
                enemy.enemyMovementSpeed = 0f;
                enemy.enemyRangeDMG = 2;
                enemy.enemyRangeSpeed = 8f;
                enemy.fireRate = 3f;
                enemyBullet.projectile.transform.localScale = new Vector3(2f, 2f, 2f);
                animator.SetBool("isCharging", true);
            }
            else if(changeMiscar)
            {
                enemy.destroyProjectile = 5f;
                enemy.enemyMovementSpeed = 2f;
                enemy.enemyRangeSpeed = 0f;
                enemy.enemyRangeDMG = 2;
                enemy.fireRate = 4f;
                enemyBullet.projectile.transform.localScale = new Vector3(1f, 1f, 1f);
                animator.SetBool("isCharging", false);
            }

        }
        else if (enemy.currentEnemyHP > (enemies.maxEnemyHp / 2))
        {
            enemyBullet.projectile.transform.localScale = new Vector3(3f, 3f, 3f);
        }

        else if(enemy.currentEnemyHP == 1)
        {
            enemy.destroyProjectile = 20f;
            enemy.enemyMovementSpeed = 0f;
            enemy.enemyRangeDMG = 8;
            enemy.fireRate = 0.3f;
            StartCoroutine(SafeMiscar());
            enemyBullet.projectile.transform.localScale = new Vector3(6.5f, 6.5f, 6.5f);
            miscarObject.transform.position = new Vector2(0f, 5.5f);
            animator.SetBool("isCharging", true);
            enemyBullet.canShoot = false;
        }
        else if (enemy.currentEnemyHP == 0)
        {
            animator.SetBool("isCharging", false);
        }
    }

    IEnumerator SafeMiscar()
    {
        if(lastHp)
        enemy.enemyRangeSpeed = 0f;
        yield return new WaitForSeconds(1.5f);
        enemy.enemyRangeSpeed = 5.5f;
        lastHp = false;
    }

    IEnumerator Berserk()
    {
        cooldownMiscar = true;
        yield return new WaitForSeconds(2f);
        if (changeMiscar)
        {         
            changeMiscar = false;
        }
        else if (!changeMiscar)
        {
            changeMiscar = true;
        }
        cooldownMiscar = false;
    }

    void ChangeSkill()
    {
        if (!cooldownMiscar)
        {
            StartCoroutine(Berserk());
            if (changeMiscar)
            {
                random = Random.Range(0, 2);
                Debug.Log(random);
            }
        }
         

    }
}


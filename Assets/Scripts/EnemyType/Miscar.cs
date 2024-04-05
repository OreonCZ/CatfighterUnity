using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miscar : MonoBehaviour
{
    public Enemy enemy;
    public MiscarBulletScript enemyBullet;
    public int random;
    bool changeMiscar = true;
    bool cooldownMiscar = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MiscarChange();
        
    }

    void MiscarChange()
    {
        if (enemy.currentEnemyHP <= 8)
        {
            ChangeSkill();
            
            if(random == 0)
            {
                enemy.enemyMovementSpeed = 0f;
                enemy.enemyRangeDMG = 6;
                enemy.enemyRangeSpeed = 5f;
                enemyBullet.projectile.transform.localScale = new Vector3(6f, 6f, 6f);
            }
            else if(random == 1)
            {
                enemy.destroyProjectile = 20f;
                enemy.enemyMovementSpeed = 2f;
                enemy.enemyRangeSpeed = 0f;
                enemy.enemyRangeDMG = 2;
                enemy.fireRate = 2f;
                enemyBullet.projectile.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (random == 2)
            {
                enemy.destroyProjectile = 20f;
                enemy.enemyMovementSpeed = 4f;
                enemy.fireRate = 0f;
            }


        }
        if (enemy.currentEnemyHP > 8)
        {
            enemyBullet.projectile.transform.localScale = new Vector3(3f, 3f, 3f);
        }
    }

    IEnumerator Berserk()
    {
        cooldownMiscar = true;
        yield return new WaitForSeconds(4f);
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
                random = Random.Range(0, 3);
                Debug.Log(random);
            }
        }
         

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscar : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private GameObject[] coins;
    int count;
    public Enemy enemy;
    public Enemies enemies;
    public TakingDmgPlayer takingDmgPlayer;
    public OscarBulletShoot oscarBulletShoot;
    public GameObject turret1;
    public GameObject turret2;
    public GameObject turret3;
    public GameObject turret4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        count = coins.Length;
        //Debug.Log(count);
        CointCoins();
        if (enemy.currentEnemyHP <= enemies.maxEnemyHp && enemy.currentEnemyHP >= 2)
        {
            oscarBulletShoot.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            enemy.enemyRangeDMG = 1;
        }

        if (enemy.currentEnemyHP < 2 && enemy.currentEnemyHP > 0)
        {
            oscarBulletShoot.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            enemy.enemyRangeDMG = 2;
        }
        if (enemy.currentEnemyHP <= 0)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    void CointCoins()
    {
        if (count >= 20)
        {
            if (!takingDmgPlayer.enemyTakeDmg)
            {
                enemy.enemyMovementSpeed = 4f;
            }
            enemy.enemyDMG = 4;
            spriteRenderer.color = new Color(1f, 1f, 0f, 0.5f);
        }

        else if (count < 20 && count >= 15)
        {
            if (!takingDmgPlayer.enemyTakeDmg)
            {
                enemy.enemyMovementSpeed = 3f;
            }
            enemy.enemyDMG = 3;
            spriteRenderer.color = new Color(1f, 1f, 0.4f, 1f);
            turret3.SetActive(true);
            turret1.SetActive(true);
        }
        else if (count < 15 && count >= 10)
        {
            if (!takingDmgPlayer.enemyTakeDmg)
            {
                enemy.enemyMovementSpeed = 2f;
            }
            enemy.enemyDMG = 2;
            spriteRenderer.color = new Color(1f, 1f, 0.8f, 1f);
            turret3.SetActive(false);
            turret1.SetActive(false);
        }
        else if (count < 10 && count >= 5)
        {
            if (!takingDmgPlayer.enemyTakeDmg)
            {
                enemy.enemyMovementSpeed = enemies.enemySpeed;
            }
            enemy.enemyDMG = 2;
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            turret4.SetActive(true);
            turret2.SetActive(true);
        }
        else
        {
            if (!takingDmgPlayer.enemyTakeDmg)
            {
                enemy.enemyMovementSpeed = enemies.enemySpeed;
            }
            enemy.enemyDMG = enemies.enemyDamage;
            turret4.SetActive(false);
            turret2.SetActive(false);
            turret3.SetActive(false);
            turret1.SetActive(false);
        }
    }
}

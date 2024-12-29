using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class Oscar : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private GameObject[] coins;
    int count;
    EnemySoldier enemySoldier;
    public Enemies enemies;
    public OscarBulletShoot oscarBulletShoot;
    public GameObject turret1;
    public GameObject turret2;
    public GameObject turret3;
    public GameObject turret4;
    public GameObject oscarTrail;
    ParticleSystem particleSystem;
    GameObject player;
    PlayerStats playerStats;
    EnemyHP enemyHP;
    public bool oscarCanShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemySoldier = GetComponent<EnemySoldier>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        playerStats = player.GetComponent<PlayerStats>();
        enemyHP = GetComponent<EnemyHP>();
    }

    // Update is called once per frame
    void Update()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        count = coins.Length;
        //Debug.Log("Coins: " +count);
        OscarPowerUp();
        OscarPhases();
        Debug.Log(oscarCanShoot);
    }

    void OscarPowerUp()
    {
        if (count < 3)
        {
            spriteRenderer.color = Color.white;
            enemySoldier.enemyMovementSpeed = enemies.enemySpeed;
            oscarTrail.SetActive(false);
            enemySoldier.enemyDMG = enemies.enemyDamage;
            particleSystem.Stop();
        }
        else if (count >= 3 && count < 6)
        {
            spriteRenderer.color = new Color32(255, 255, 170, 255);
            enemySoldier.enemyMovementSpeed = enemies.enemySpeed + 1f;
            enemySoldier.enemyDMG = (enemies.enemyDamage + 1f);
            oscarTrail.SetActive(false);
            particleSystem.Stop();
        }
        else if (count >= 6 && count < 10)
        {
            spriteRenderer.color = new Color32(255, 255, 150, 255);
            enemySoldier.enemyMovementSpeed = enemies.enemySpeed + 8f;
            enemySoldier.enemyDMG = (enemies.enemyDamage + 2f);
            oscarTrail.SetActive(true);
            particleSystem.Play();
            //RegenerateHP(0.5f);
        }
        else
        {
            spriteRenderer.color = new Color32(255, 255, 0, 255);
            enemySoldier.enemyMovementSpeed = enemies.enemySpeed + 20f;
            enemySoldier.enemyDMG = playerStats.playerMaxHP / 4;
            oscarTrail.SetActive(true);
            particleSystem.Play();
            RegenerateHP(2f);
        }
    }

    public void RegenerateHP(float amount)
    {
        if (enemyHP.currentSoldierHp < enemySoldier.maxEnemyHP)
        {
            enemyHP.currentSoldierHp += amount * Time.deltaTime;
            enemyHP.currentSoldierHp = Mathf.Min(enemyHP.currentSoldierHp, enemySoldier.maxEnemyHP);
        }
    }

    void OscarPhases()
    {
        if(enemyHP.currentSoldierHp < (enemySoldier.maxEnemyHP / 2)){
            oscarCanShoot = true;
        }
    }
        
}

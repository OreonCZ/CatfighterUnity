using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Slider slider;
    public Enemies enemy;
    public Fight fight;
    public TakingDMG takingDmgEnemy1;
    public TakingDMG takingDmgEnemy2;
    public TakingDMG takingDmgEnemy3;
    public TakingDMG takingDmgEnemy4;
    public bool enemyDed = false;
    string catEnemy1 = "Kevin";
    public string catEnemy2 = "Yuki";
    public string catEnemy3 = "Miscar";
    string catEnemy4 = "Bingus";
    public string catEnemy5 = "Oscar";
    string catEnemy6 = "Brucha";
    public Animator animator;
    public GameObject enemyObject;
    public GameObject portalBack;
    public GameObject enemyHpBar;
    int maxEnemyHP;
    public int currentEnemyHP;
    public int enemyRangeDMG;
    public float enemyRangeSpeed;
    public float destroyProjectile;
    public float fireRate;
    public int enemyDMG;
    public float enemyMovementSpeed;
    public bool bingusSecond = false;

    void Start()
    {
        enemyMovementSpeed = enemy.enemySpeed;
        maxEnemyHP = enemy.maxEnemyHp;
        slider.maxValue = maxEnemyHP;
        currentEnemyHP = maxEnemyHP;
        slider.value = currentEnemyHP;
        enemyRangeDMG = enemy.shootDamage;
        enemyRangeSpeed = enemy.fireSpeed;
        enemyDMG = enemy.enemyDamage;
        destroyProjectile = enemy.destroyProjectile;
        fireRate = enemy.fireRate;
    }
    void Update()
    {
        if(currentEnemyHP <= 0)
        {
            enemyDed = true;
            //Destroy(enemyObject);
            portalBack.SetActive(true);
            enemyHpBar.SetActive(false);
            SaveNumber();
        }

    }
    public void SaveNumber()
    {
        if(catEnemy1 == enemy.catName) {
        PlayerPrefs.SetInt("level1", 1);
        PlayerPrefs.SetInt("KevinKilled", 0);
            if (takingDmgEnemy1.isKilled || takingDmgEnemy2.isKilled || takingDmgEnemy3.isKilled || takingDmgEnemy4.isKilled)
            {
                PlayerPrefs.SetInt("KevinKilled", 1);
            }
        }
        else if (catEnemy2 == enemy.catName)
        {
            PlayerPrefs.SetInt("level2", 1);
            PlayerPrefs.SetInt("YukiKilled", 0);
            if (takingDmgEnemy1.isKilled || takingDmgEnemy2.isKilled || takingDmgEnemy3.isKilled || takingDmgEnemy4.isKilled)
            {
                PlayerPrefs.SetInt("YukiKilled", 1);
            }
        }
        else if (catEnemy3 == enemy.catName)
        {
            PlayerPrefs.SetInt("level3", 1);
            PlayerPrefs.SetInt("MiscarKilled", 0);
            if (takingDmgEnemy1.isKilled || takingDmgEnemy2.isKilled || takingDmgEnemy3.isKilled || takingDmgEnemy4.isKilled)
            {
                PlayerPrefs.SetInt("MiscarKilled", 1);
            }
        }
        else if (catEnemy4 == enemy.catName)
        {
            PlayerPrefs.SetInt("level4", 1);
            PlayerPrefs.SetInt("BingusKilled", 0);
            if (takingDmgEnemy1.isKilled || takingDmgEnemy2.isKilled || takingDmgEnemy3.isKilled || takingDmgEnemy4.isKilled)
            {
                PlayerPrefs.SetInt("BingusKilled", 1);
            }
        }
        else if (catEnemy5 == enemy.catName)
        {
            PlayerPrefs.SetInt("level5", 1);
            PlayerPrefs.SetInt("OscarKilled", 0);
            if (takingDmgEnemy1.isKilled || takingDmgEnemy2.isKilled || takingDmgEnemy3.isKilled || takingDmgEnemy4.isKilled)
            {
                PlayerPrefs.SetInt("OscarKilled", 1);
            }
        }
        else if (catEnemy6 == enemy.catName)
        {
            PlayerPrefs.SetInt("level6", 6);
            PlayerPrefs.SetInt("BruchaKilled", 0);
            if (takingDmgEnemy1.isKilled || takingDmgEnemy2.isKilled || takingDmgEnemy3.isKilled || takingDmgEnemy4.isKilled)
            {
                PlayerPrefs.SetInt("BruchaKilled", 1);
            }
        }
    }

}


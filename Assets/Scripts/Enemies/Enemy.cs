using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Slider slider;
    public Enemies enemy;
    public Fight fight;
    public bool enemyDed = false;
    string catEnemy1 = "Kevin";
    string catEnemy2 = "Yuki";
    string catEnemy3 = "Miscar";
    string catEnemy4 = "Bingus";
    string catEnemy5 = "Oscar";
    string catEnemy6 = "Brucha";
    public Animator animator;
    public GameObject enemyObject;
    public GameObject portalBack;
    public GameObject enemyHpBar;
    int maxEnemyHP;
    public int currentEnemyHP;

    void Start()
    {
        maxEnemyHP = enemy.maxEnemyHp;
        slider.maxValue = maxEnemyHP;
        currentEnemyHP = maxEnemyHP;
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
        PlayerPrefs.SetInt("level", 1);
        }
        else if (catEnemy2 == enemy.catName)
        {
            PlayerPrefs.SetInt("level", 2);
        }
        else if (catEnemy3 == enemy.catName)
        {
            PlayerPrefs.SetInt("level", 3);
        }
        else if (catEnemy4 == enemy.catName)
        {
            PlayerPrefs.SetInt("level", 4);
        }
        else if (catEnemy5 == enemy.catName)
        {
            PlayerPrefs.SetInt("level", 5);
        }
        else if (catEnemy6 == enemy.catName)
        {
            PlayerPrefs.SetInt("level", 6);
        }
    }

}


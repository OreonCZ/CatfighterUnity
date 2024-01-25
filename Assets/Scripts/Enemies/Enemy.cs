using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Slider slider;
    public Enemies enemy;
    public Fight fight;
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
            Destroy(enemyObject);
            portalBack.SetActive(true);
            enemyHpBar.SetActive(false);
        }
    }

    }


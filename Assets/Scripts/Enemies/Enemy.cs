using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Slider slider;
    public Enemies enemy;
    public Fight fight;
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
    }

    }


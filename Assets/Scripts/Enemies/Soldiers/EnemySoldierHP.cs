using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;
using UnityEngine.UI;

public class EnemySoldierHP : MonoBehaviour
{
    EnemySoldier enemySoldier;
    [HideInInspector] public GameObject enemyHpBar;
    [HideInInspector] public Slider enemyHpSlider;
    [HideInInspector] public float currentSoldierHp;

    // Start is called before the first frame update
    void Start()
    {
        enemySoldier = GetComponent<EnemySoldier>();
        enemyHpBar = transform.Find("EnemyBar").gameObject;
        enemyHpSlider = enemyHpBar.GetComponentInChildren<Slider>();

        currentSoldierHp = enemySoldier.maxEnemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHpSlider != null)
        {
            enemyHpSlider.value = currentSoldierHp;
        }
        Debug.Log(enemySoldier.maxEnemyHP);
        if (currentSoldierHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
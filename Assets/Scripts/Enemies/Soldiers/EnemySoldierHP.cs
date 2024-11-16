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
        enemyHpBar = GameObject.FindGameObjectWithTag(ObjectTags.enemyHpBar.ToString());
        enemyHpSlider = enemyHpBar.GetComponent<Slider>();

        currentSoldierHp = enemySoldier.maxEnemyHP;

        enemyHpSlider.maxValue = enemySoldier.maxEnemyHP;
        enemyHpSlider.value = enemySoldier.maxEnemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentSoldierHp);
        if (currentSoldierHp <= 0)
        {
            //Destroy(gameObject);
        }
    }
}

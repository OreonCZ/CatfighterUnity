using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider slider;
    public int maxHp = 8;
    public int currentHp;
    public GameObject dedScreen;
    public GameObject gameBar;
    public GameObject enemy;
    public EnemyMovement enemyMovement;
    public bool isDed = false;

    void Start()
    {
        currentHp = maxHp;
        slider.maxValue = maxHp;
    }

    void Update()
    {
        slider.value = currentHp;
        if (Input.GetKey(KeyCode.E))
        {
            currentHp -= 1;
        }

        if(currentHp <= 0) {
            dedScreen.SetActive(true);
            gameBar.SetActive(false);
            enemyMovement.enemyCanMove = false;
            Destroy(enemy);
            Debug.Log("ded");
            isDed = true;
        }
    }
}

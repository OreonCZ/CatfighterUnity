using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakingDMG : MonoBehaviour
{
    public bool isHit;
    public bool isKilled = false;
    public Slider slider;
    public Fight fight;
    public Enemy enemy;
    public Animator animator;
    public float enemyStun = 2f;
    GameObject swordRadius;

    void Start()
    {
        swordRadius = GameObject.FindWithTag("Sword");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            enemy.currentEnemyHP -= fight.attackDamage;
            slider.value = enemy.currentEnemyHP;
            swordRadius.SetActive(false);
            
        }
        if (collider.gameObject.tag == "Enemy" && enemy.enemyDed)
        {
            isKilled = true;
        }
    }
}


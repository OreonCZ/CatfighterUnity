using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakingDMG : MonoBehaviour
{
    public bool isHit;
    public Slider slider;
    public Fight fight;
    public Enemy enemy;
    bool hit;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            enemy.currentEnemyHP -= fight.attackDamage;
            slider.value = enemy.currentEnemyHP;
        }
    }
}


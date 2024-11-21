using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileDMG : MonoBehaviour
{
    public HpBar hpbar;
    Movement playerMovement;
    private void Start()
    {
        //hpbar = GetComponent<HpBar>();
        //playerMovement = GetComponent<Movement>();
    }

    public void OnHitDamage(float damage)
    {
        hpbar.currentHp -= damage;
        hpbar.slider.value -= damage;
        Debug.Log("hp: " + hpbar.currentHp);
    }
}

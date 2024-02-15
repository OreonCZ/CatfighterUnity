using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileDMG : MonoBehaviour
{
    public HpBar hpbar;
    public Movement playerMovement;

    public void OnHitDamage(int damage)
    {
        if (!playerMovement.isRolling) {
        hpbar.currentHp -= damage;
        hpbar.slider.value -= damage;
        Debug.Log("hp: " + hpbar.currentHp);
        }
    }
}

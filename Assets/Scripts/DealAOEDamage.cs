using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class DealAOEDamage : MonoBehaviour
{
    GameObject player;
    HpBar hpBar;
    Movement movement;
    EnemySoldier enemySoldier;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        hpBar = player.GetComponent<HpBar>();
        movement = player.GetComponent<Movement>();
        enemySoldier = GetComponentInParent<EnemySoldier>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ObjectTags.Player.ToString()) && !movement.isRolling && enemySoldier.name == "FBingus"){
            hpBar.currentHp -= (hpBar.maxHp / 2);
        }
        if (other.CompareTag(ObjectTags.Player.ToString()) && !movement.isRolling && enemySoldier.name == "Luna")
        {
            hpBar.currentHp -= (hpBar.maxHp / damage);
        }
    }
}

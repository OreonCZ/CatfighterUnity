using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class DealAOEDamage : MonoBehaviour
{
    GameObject player;
    HpBar hpBar;
    Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        hpBar = player.GetComponent<HpBar>();
        movement = player.GetComponent<Movement>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ObjectTags.Player.ToString()) && !movement.isRolling){
            hpBar.currentHp -= (hpBar.maxHp / 2);
        }
    }
}

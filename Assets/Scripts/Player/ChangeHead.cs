using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.EnumTypes;

public class ChangeHead : MonoBehaviour
{
    public Image head;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    [SerializeField] GameObject slider2;
    GameObject player;
    HpBar hpBar;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        hpBar = player.GetComponent<HpBar>();
    }

    void Update()
    {
        if(hpBar.currentHp > (hpBar.maxHp / 2))
        {
            head.sprite = sprite1;
        }

       else if(hpBar.currentHp > (hpBar.maxHp / 4) && hpBar.currentHp <= (hpBar.maxHp / 2))
        {
            head.sprite = sprite2;
        }
        else if (hpBar.currentHp <= (hpBar.maxHp / 4))
        {
            head.sprite = sprite3;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.EnumTypes;

public class MilkUI : MonoBehaviour
{
    Milk milk;
    GameObject player;
    public Text numberOfMilk;
    string currentMilkString;
    PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        milk = player.GetComponent<Milk>();
        playerStats = player.GetComponent<PlayerStats>();
        

    }

    // Update is called once per frame
    void Update()
    {
        currentMilkString = milk.numberOfMilk.ToString();
        numberOfMilk.text = currentMilkString;
    }
}

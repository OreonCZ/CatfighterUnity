using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.EnumTypes;

public class HpBar : MonoBehaviour
{
    [HideInInspector] public Slider slider;
    public float maxHp;
    public float currentHp;
    public GameObject dedScreen;
    public GameObject gameBar;
    GameObject hpBorder;
    //public GameObject enemy;
    public bool isDed = false;

    GameObject player;
    PlayerStats playerStats;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        hpBorder = GameObject.FindGameObjectWithTag(ObjectTags.hpBorder.ToString());
        //dedScreen = GameObject.FindGameObjectWithTag(ObjectTags.dedScreen.ToString());
        //gameBar = GameObject.FindGameObjectWithTag(ObjectTags.gameUI.ToString());

        playerStats = player.GetComponent<PlayerStats>();
        slider = hpBorder.GetComponent<Slider>();

        maxHp = playerStats.playerMaxHP;
        currentHp = maxHp;
        slider.maxValue = maxHp;
    }

    void Update()
    {
        slider.value = currentHp;

        if(currentHp <= 0) {
            dedScreen.SetActive(true);
            gameBar.SetActive(false);
            //enemyMovement.enemyCanMove = false;
            //Destroy(enemy);
            //Debug.Log("ded");
            isDed = true;
            PauseGame.canPause = false;
        }
    }
}

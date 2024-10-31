using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.EnumTypes;

public class HpBar : MonoBehaviour
{
    public Slider slider;
    public float maxHp;
    public float currentHp;
    public Movement playerMovement;
    public GameObject dedScreen;
    public GameObject gameBar;
    //public GameObject enemy;
    public EnemyMovement enemyMovement;
    public bool isDed = false;
    public PauseGame pauseGame;

    GameObject player;
    PlayerStats playerStats;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        playerStats = player.GetComponent<PlayerStats>();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    EnemySoldier enemySoldier;
    public EnemySoldierAttack enemySoldierAttack;
    public EnemyRangerAttack enemyRangerAttack;
    public EnemyBulletAttack enemyBulletAttack;
    public GameObject enemyHpBar;
    [HideInInspector] public Slider enemyHpSlider;
    [HideInInspector] public float currentSoldierHp;
    EnemySoldierMoving enemySoldierMoving;
    public Animator animator;
    public bool isDefeated = false;
    public bool isKilled = false;
    GameObject player;
    PlayerStats playerStats;
    public GameObject exitButton;
    AudioSource audioSource;
    GameObject music;
    ParticleSystem particleSystem;

    // Start is called before the first frame update

    void Start()
    {
        enemySoldier = GetComponent<EnemySoldier>();
        enemySoldierMoving = GetComponent<EnemySoldierMoving>();
        //Debug.Log(currentSoldierHp + " " + enemySoldier.maxEnemyHP);
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        playerStats = player.GetComponent<PlayerStats>();

        enemyHpSlider = enemyHpBar.GetComponent<Slider>();
        music = GameObject.Find("Music");
        audioSource = music.GetComponent<AudioSource>();

        currentSoldierHp = enemySoldier.maxEnemyHP;
        enemyHpSlider.maxValue = enemySoldier.maxEnemyHP;

        particleSystem = GetComponentInChildren<ParticleSystem>();

        //enemySoldier.EnemyAttackDiff(enemySoldierAttack, enemyRangerAttack, enemyBulletAttack);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHpSlider != null)
        {
            enemyHpSlider.value = currentSoldierHp;
        }
        if (currentSoldierHp <= 0)
        {
            DiffCat();
            if (animator != null)
            {
                animator.SetBool("Ko", true);
            }
            //animator.Play("SoldierKO");
            isDefeated = true;
            exitButton.SetActive(true);
            enemySoldierMoving.agent.isStopped = true;
            enemySoldierMoving.isFollowing = false;
            enemySoldier.EnemyNameCompare();
            enemyHpBar.SetActive(false);
            PlayerPrefs.SetInt("BossDefeated_" + enemySoldier.name, 1);
            if (isKilled)
            {
                animator.SetBool("Ko", false);
                animator.SetBool("IsDead", true);
                audioSource.Pause();
                PlayerPrefs.SetInt("BossDefeated_" + enemySoldier.name, 2);
            }
        }
    }

    void GetMoneyOnce(int value)
    {
        if(!isKilled) playerStats.IncreaseMoney(value * enemySoldier.catLvl);
    }

    private void DiffCat()
    {
        if ("Kevin" == enemySoldier.catName)
        {
            enemySoldierAttack.soldierCanAttack = false;
            enemySoldierAttack.soldierAttacks = false;
            //GetMoneyOnce(10);
        }
        if ("Yuki" == enemySoldier.catName)
        {
            enemySoldierAttack.soldierCanAttack = false;
            enemySoldierAttack.soldierAttacks = false;
            animator.SetBool("isReloading", false);
            //GetMoneyOnce(10);
        }
        if ("Bingus" == enemySoldier.catName)
        {
            enemySoldierAttack.soldierCanAttack = false;
            enemySoldierAttack.soldierAttacks = false;
            //GetMoneyOnce(10);
        }
        if ("Miscar" == enemySoldier.catName)
        {
            enemySoldierAttack.soldierCanAttack = false;
            enemySoldierAttack.soldierAttacks = false;
            animator.SetBool("isReloading", false);
            particleSystem.Stop();
            //GetMoneyOnce(10);
        }
        if ("Oscar" == enemySoldier.catName)
        {
            enemySoldierAttack.soldierCanAttack = false;
            enemySoldierAttack.soldierAttacks = false;
            //GetMoneyOnce(10);
        }
        if ("Brucha" == enemySoldier.catName)
        {
            enemySoldierAttack.soldierCanAttack = false;
            enemySoldierAttack.soldierAttacks = false;
            //GetMoneyOnce(10);
        }
        /*if ("Fiend" == enemySoldier.catName)
        {
            enemySoldierAttack.soldierCanAttack = false;
            enemySoldierAttack.soldierAttacks = false;
            GetMoneyOnce(4);
        }
        if ("Ranger" == enemySoldier.catName)
        {
            //enemyRangerAttack.soldierAttacks = false;
            //enemyRangerAttack.soldierCanAttack = false;
            GetMoneyOnce(1);
        }
        if ("Intruder" == enemySoldier.catName)
        {
            enemySoldierAttack.soldierAttacks = false;
            enemySoldierAttack.soldierCanAttack = false;
            GetMoneyOnce(5);
        }*/
    }
}


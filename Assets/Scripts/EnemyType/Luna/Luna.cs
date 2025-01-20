using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.EnumTypes;
using UnityEngine.Tilemaps;

public class Luna : MonoBehaviour
{

    PlayerStats playerStats;
    Animator animator;
    EnemySoldierMoving enemySoldierMoving;
    GameObject player;
    EnemySoldier enemySoldier;
    public Enemies enemies;
    Movement playerMovement;
    HpBar hpBar;
    public GameObject attackCollider;
    CircleCollider2D attackCircle;

    private float abilityCooldown = 3f;
    float abilityTimer = 0f;

    GameObject[] aoe;

    SpriteRenderer spriteRenderer;
   
    private bool transformLuna = false;
    EnemyHP enemyHP;
    public GameObject transformUI;
    Fight fight;
    GameObject firstTransition;

    public Text lunaName;
    string lunaBossName;

    public GameObject projectile;
    
    public GameObject aoeArea;
    Camera camera;
    Parry parry;

    public GameObject smash;
    public GameObject slam;

    GameObject[] changeColor;
    ParticleSystem lunaParticle;

    EnemySoldierBullet enemySoldierBullet;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemySoldierMoving = GetComponent<EnemySoldierMoving>();
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        enemySoldier = GetComponent<EnemySoldier>();
        playerMovement = player.GetComponent<Movement>();
        hpBar = player.GetComponent<HpBar>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyHP = GetComponent<EnemyHP>();
        fight = player.GetComponent<Fight>();
        parry = player.GetComponent<Parry>();
        firstTransition = GameObject.Find("FirstTransition");
        attackCircle = attackCollider.GetComponent<CircleCollider2D>();
        playerStats = player.GetComponent<PlayerStats>();
        enemySoldierBullet = GetComponent<EnemySoldierBullet>();
        aoeArea = GameObject.Find("CoinSpawnArea");
        camera = GameObject.Find("Camera").GetComponent<Camera>();

        lunaParticle = GetComponentInChildren<ParticleSystem>();

        changeColor = GameObject.FindGameObjectsWithTag(ObjectTags.LunaChange.ToString());
        abilityTimer += 2f;
    }

    // Update is called once per frame
    void Update()
    {
        LunaPhases();
        aoe = GameObject.FindGameObjectsWithTag(ObjectTags.LunaAOE.ToString());
    }

    void LunaPhases()
    {
        if (enemyHP.currentSoldierHp > 0)
        {
            if (enemyHP.currentSoldierHp <= (enemySoldier.maxEnemyHP / 2))
            {
                lunaBossName = "Luna, the Perfect Lifeform";
                lunaName.text = lunaBossName;
                StartCoroutine(Transformation());
            }
            if (transformLuna)
            {
                LunaAbilities2();
            }
            else if (!transformLuna)
            {
                LunaAbilities();
            }
        }
        else
        {
            foreach (GameObject obj in changeColor)
            {
                Tilemap tilemap = obj.GetComponent<Tilemap>();
                tilemap.color = new Color32(255, 255, 255, 255);
            }
            enemySoldier.enemyDMG = 0f;
            StartCoroutine(DeadDestroy());
        }
    }

    IEnumerator DeadDestroy()
    {
        animator.SetBool("Ko", true);
        yield return new WaitForSeconds(0.43f);
        Destroy(gameObject);
    }

    IEnumerator Transformation()
    {
        if (!transformLuna)
        {
            float angle = Random.Range(0f, 360f);
            gameObject.transform.position = Quaternion.Euler(0f, 0f, angle) * new Vector2(0, 5) + new Vector3(player.transform.position.x, player.transform.position.y);
            animator.SetBool("Transform", true);
            animator.SetTrigger("Change");
            playerMovement.canWalk = false;
            fight.canAttack = false;
            enemySoldier.enemyRangeDMG = 0f;
            enemySoldier.enemyRangeSpeed = 0f;
            enemySoldier.enemyDMG = 0f;
            enemySoldierBullet.wait = false;
            transformUI.SetActive(true);
            enemySoldierMoving.isFollowing = false;
            enemySoldier.enemyRangeSpeed = 30f;

            yield return new WaitForSeconds(3.25f);

            foreach(GameObject obj in aoe)
            {
                Destroy(obj);
            }

            foreach (GameObject obj in changeColor)
            {
              Tilemap tilemap = obj.GetComponent<Tilemap>();
                tilemap.color = new Color32(141, 153, 255, 233);
            }

            enemySoldierBullet.wait = true;
            enemySoldierMoving.isFollowing = true;
            enemyHP.currentSoldierHp = enemySoldier.maxEnemyHP;

            enemySoldier.enemyDMG = 3.4f;
            enemySoldier.fireRate = 8f;
            enemySoldier.destroyProjectile = 2f;
            enemySoldier.enemyMovementSpeed = 1f;
            transformLuna = true;
            transformUI.SetActive(false);
            fight.canAttack = true;
            playerMovement.canWalk = true;
            firstTransition.SetActive(true);

        }
    }

    void LunaAbilities()
    {
        abilityTimer -= Time.deltaTime;
        if (abilityTimer <= 0f)
        {
            ChooseRandomAbility(Random.Range(1, 6));
            abilityTimer = abilityCooldown;
        }
    }
    void LunaAbilities2()
    {
        abilityTimer -= Time.deltaTime;
        if (abilityTimer <= 0f)
        {
            ChooseRandomAbility2(Random.Range(1, 6));
            abilityTimer = abilityCooldown;
        }
    }

    IEnumerator LunaBlessing(float heal)
    {
        SpawnAtPlayer(Random.Range(3f, 6f), 1f, 0.5f);
        animator.SetTrigger("Blessing");
        enemySoldierMoving.isFollowing = false;
        yield return new WaitForSeconds(1.5f);
        if (enemyHP.currentSoldierHp + heal < enemySoldier.maxEnemyHP)
        {
            enemyHP.currentSoldierHp += heal;
        }
        enemySoldierMoving.isFollowing = true;
    }

    IEnumerator LunaAmbush()
    {
        if (transformLuna) lunaParticle.Play();
        animator.SetTrigger("LunaAmbush");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Pome");
        gameObject.transform.position = Quaternion.Euler(0f, 0f, 0) * new Vector2(0, 0) + new Vector3(player.transform.position.x, player.transform.position.y);
        if (!playerMovement.isRolling || !parry.isParrying)
        {
           hpBar.currentHp -= enemySoldier.enemyDMG;
        }
    }
    IEnumerator FasterSpawn(float bulletSpeedMulti, float time)
    {
        enemySoldierMoving.isFollowing = false;
        enemySoldier.fireRate = enemies.fireRate + bulletSpeedMulti;
        animator.SetTrigger("FasterSpawn");
        yield return new WaitForSeconds(time);
        enemySoldierMoving.isFollowing = true;
        enemySoldier.fireRate = enemies.fireRate;
    }
    void SpawnAtPlayer(float bludimir, float random, float scale)
    {
        for (int i = 0; i < bludimir; i++)
        {
            float angle = Random.Range(0f, 360f);
            Vector2 direction = (player.transform.position - transform.position).normalized;
            Vector2 spawnPosition = Quaternion.Euler(0f, 0f, angle) * new Vector2(random, random) + new Vector3(player.transform.position.x, player.transform.position.y);
            GameObject bullet = Instantiate(projectile, spawnPosition, Quaternion.identity);
            bullet.transform.localScale = new Vector2(scale, scale);
            EnemySoldierShoot bulletComponent = bullet.GetComponent<EnemySoldierShoot>();
            if (bulletComponent != null)
            {
                bulletComponent.direction = direction;
                bulletComponent.enemy = gameObject;
                bulletComponent.EnemyInitialization(this.gameObject);
            }
        }
    }

    IEnumerator AoeAbility(GameObject aoe, string trigger)
    {
        enemySoldierMoving.isFollowing = false;
        animator.SetTrigger(trigger);
        yield return new WaitForSeconds(0.5f);
        aoe.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        aoe.SetActive(false);
        enemySoldierMoving.isFollowing = true;
    }

    void ChooseRandomAbility(int random)
    {
        switch (random)
        {
            case 1:
                StartCoroutine(LunaBlessing(playerStats.playerDamage));
                break;
            case 2:
                StartCoroutine(LunaAmbush());
                break;
            case 3:
                StartCoroutine(FasterSpawn(4f, 2f));
                break;
            case 4:
                StartCoroutine(FasterSpawn(8f, 1f));
                break;
            case 5:
                SpawnAtPlayer(Random.Range(5f, 9f), Random.Range(1f, 2.5f), 0.7f);
                break;
        }
    }

    void ChooseRandomAbility2(int random)
    {
        switch (random)
        {
            case 1:
                StartCoroutine(AoeAbility(slam, "aoeSlam"));
                break;
            case 2:
                StartCoroutine(AoeAbility(smash, "aoeSmash"));
                break;
            case 3:
                StartCoroutine(LunaAmbush());
                SpawnAtPlayer(Random.Range(3f, 7f), Random.Range(1f, 2.2f), 0.7f);
                break;
            case 4:
                StartCoroutine(FasterSpawn(6f, 1f));
                SpawnAtPlayer(Random.Range(4f, 8f), Random.Range(1f, 3.4f), 1f);
                break;
            case 5:
                StartCoroutine(FasterSpawn(10f, 2f));
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;
using UnityEngine.UI;

public class FBingus : MonoBehaviour
{
    public GameObject bingusSpeedUp;
    public GameObject enemyFiend;
    public GameObject enemyFiendRose;
    ParticleSystem particleParry;
    
    int numberOfFiends;
    int numberOfFlowers;

    PlayerStats playerStats;

    Animator animator;
    EnemySoldierMoving enemySoldierMoving;
    private List<GameObject> fiends = new List<GameObject>();
    GameObject[] flowersHeal;
    private bool bingusParry = false;
    GameObject player;
    public GameObject trail;
    EnemySoldier enemySoldier;
    public Enemies enemies;
    Movement playerMovement;
    HpBar hpBar;
    public GameObject aoe;
    public GameObject attackCollider;
    CircleCollider2D attackCircle;

    CapsuleCollider2D bingusCollider;

    private float abilityCooldown = 4f;
    private float abilityTimer = 0f;
    private int maxSpawns = 4;
    private int maxFlowers = 6;

    SpriteRenderer spriteRenderer;
    private bool explosionBingus = false;
    CircleCollider2D aoeCollider;
    float nukeTime = 0f;
    private bool transformBingus = false;
    GameObject[] flowersObjects;
    EnemyHP enemyHP;
    public GameObject transformUI;
    Fight fight;
    GameObject firstTransition;

    public Text bingusName;
    string bingusBossName;

    public bool isHealing = false;

    public GameObject flowerHeal;
    public ParticleSystem bingusTurret;
    EnemySoldierBullet enemySoldierBullet;

    void Start()
    {
        animator = GetComponent<Animator>();
        particleParry = GameObject.Find("ParticlesParry").GetComponent<ParticleSystem>();
        fiends.AddRange(GameObject.FindGameObjectsWithTag(ObjectTags.Fiend.ToString()));
        enemySoldierMoving = GetComponent<EnemySoldierMoving>();
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        enemySoldier = GetComponent<EnemySoldier>();
        playerMovement = player.GetComponent<Movement>();
        hpBar = player.GetComponent<HpBar>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        aoeCollider = aoe.GetComponent<CircleCollider2D>();
        enemyHP = GetComponent<EnemyHP>();
        fight = player.GetComponent<Fight>();
        firstTransition = GameObject.Find("FirstTransition");
        attackCircle = attackCollider.GetComponent<CircleCollider2D>();
        playerStats = player.GetComponent<PlayerStats>();
        enemySoldierBullet = GetComponent<EnemySoldierBullet>();
        bingusCollider = GetComponent<CapsuleCollider2D>();


        aoe.SetActive(false);
        aoeCollider.enabled = false;
        flowersObjects = GameObject.FindGameObjectsWithTag(ObjectTags.Flowers.ToString());
        foreach (GameObject obj in flowersObjects)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        BingusPhases();
    }

    void BingusPhases()
    {
        if (enemyHP.currentSoldierHp > 0)
        {
            if (enemyHP.currentSoldierHp <= (enemySoldier.maxEnemyHP / 2))
            {
                bingusBossName = "Bingus, the Flower Abomination";
                bingusName.text = bingusBossName;
                StartCoroutine(Transformation());
            }
            if (transformBingus)
            {
                flowersHeal = GameObject.FindGameObjectsWithTag(ObjectTags.flower.ToString());
                numberOfFlowers = flowersHeal.Length;
                HealingFlower(numberOfFlowers);
                BingusAbilities2();
            }
            else if (!transformBingus)
            {
                BingusAbilities();
            }
        }
        else if(enemyHP.currentSoldierHp <= 0)
        {
            StartCoroutine(DeadExplode());
        }
    }

    void BingusAbilities()
    {
        numberOfFiends = fiends.Count;
        abilityTimer -= Time.deltaTime;
        if (abilityTimer <= 0f)
        {
            ChooseRandomAbility(Random.Range(1, 6), maxSpawns, 6f);
            abilityTimer = abilityCooldown;
        }
        if (numberOfFiends == maxSpawns)
        {
            abilityTimer = 4f;
            StartCoroutine(Explode());
        }
    }
    void BingusAbilities2()
    {
        numberOfFiends = fiends.Count;
        abilityTimer -= Time.deltaTime;
        if (abilityTimer <= 0f && !isHealing)
        {
            ChooseRandomAbility2(Random.Range(1, 6), maxSpawns, 8f);
            abilityTimer = abilityCooldown;
        }
        if (numberOfFiends == maxSpawns)
        {
            abilityTimer = 5f;
            StartCoroutine(Explode());
        }
    }

    IEnumerator Transformation()
    {
        if (!transformBingus)
        {
            float angle = Random.Range(0f, 360f);
            gameObject.transform.position = Quaternion.Euler(0f, 0f, angle) * new Vector2(0, 5) + new Vector3(player.transform.position.x, player.transform.position.y);
            trail.SetActive(false);
            animator.SetBool("Transform", true);
            animator.SetTrigger("Change");
            bingusSpeedUp.SetActive(false);
            playerMovement.canWalk = false;
            fight.canAttack = false;
            enemySoldier.enemyRangeDMG = 0f;
            enemySoldier.enemyRangeSpeed = 0f;
            enemySoldier.enemyDMG = 0f;
            enemySoldierBullet.wait = false;
            DestroyFiends();
            fiends.Clear();
            transformUI.SetActive(true);
            enemySoldierMoving.isFollowing = false;
            enemySoldier.enemyRangeSpeed = 30f;

            yield return new WaitForSeconds(2.8f);

            bingusCollider.size = new Vector2(1.4f, 1f); 
            enemySoldierBullet.wait = true;
            enemySoldierMoving.isFollowing = true;
            //enemyHP.currentSoldierHp = enemySoldier.maxEnemyHP;
            enemySoldier.enemyRangeSpeed = 10f;
            enemySoldier.enemyMovementSpeed = 2f;
            enemySoldier.enemyDMG = (enemies.enemyDamage - 1f);
            enemySoldier.enemyRangeDMG = 2.6f;
            attackCircle.radius = 0.7f;
            foreach (GameObject obj in flowersObjects)
            {
                obj.SetActive(true);
            }
            transformBingus = true;
            transformUI.SetActive(false);
            fight.canAttack = true;
            playerMovement.canWalk = true;
            firstTransition.SetActive(true);
            bingusTurret.Stop();
        }
    }

    void RegisterFiend(GameObject fiend)
    {
        fiends.Add(fiend);
    }

    void DestroyFiends()
    {
        foreach (GameObject fiend in fiends)
        {
            if (fiend != null)
            {
                Destroy(fiend);
            }
        }
        fiends.Clear();
    }

    IEnumerator DeadExplode()
    {
        enemySoldierMoving.isFollowing = false;
        aoe.SetActive(true);
        aoeCollider.enabled = true;
        animator.SetBool("Ko", true);
        DestroyFiends();

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            nukeTime = Mathf.Lerp(0f, 1f, elapsedTime / 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        nukeTime = 0f;
        aoeCollider.enabled = false;
        aoe.SetActive(false);
        Destroy(gameObject);
    }

    IEnumerator Explode()
    {
        enemySoldierMoving.isFollowing = false;
        aoe.SetActive(true);
        aoeCollider.enabled = true;
        animator.SetTrigger("Nuke");
        DestroyFiends();

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            nukeTime = Mathf.Lerp(0f, 1f, elapsedTime / 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        nukeTime = 0f;
        aoeCollider.enabled = false;
        aoe.SetActive(false);
        enemySoldierMoving.isFollowing = true;
        animator.SetBool("Idle", true);
    }

    void AbilityOneBingus(int maxSpawns)
    {
        if (numberOfFiends <= maxSpawns)
        {
            animator.SetTrigger("Summon");
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * 2f;
            int randomFiend = Random.Range(0, 2);
            if(randomFiend == 0)
            {
                GameObject newFiend = Instantiate(enemyFiend, randomPosition, Quaternion.identity);
                RegisterFiend(newFiend);
            }
            else
            {
                GameObject newFiend = Instantiate(enemyFiendRose, randomPosition, Quaternion.identity);
                RegisterFiend(newFiend);
            }
        }
    }
    IEnumerator AbilityParryBingus(){
        bingusParry = true;
        particleParry.Play();
        yield return new WaitForSeconds(particleParry.duration);
        bingusParry = false;
    }
    IEnumerator AbilityTeleportBingus(float value, float bulletSpeedMulti, float seconds, bool canShoot)
    {
        animator.SetTrigger("Teleport");
        yield return new WaitForSeconds(0.2f);
        float angle = Random.Range(0f, 360f);
        gameObject.transform.position = Quaternion.Euler(0f, 0f, angle) * new Vector2(value, value) + new Vector3(player.transform.position.x, player.transform.position.y);
        if(canShoot) StartCoroutine(AbilityShootBingus(bulletSpeedMulti, seconds));
    }
    IEnumerator AbilityShootBingus(float value, float seconds)
    {
        enemySoldierBullet.nextFire = 0f;
        animator.SetTrigger("Shoot");
        enemySoldier.enemyRangeSpeed = (enemySoldier.enemyRangeSpeed + value);
        enemySoldier.fireRate = (enemySoldier.fireRate + value);
        enemySoldierMoving.isFollowing = false;
        yield return new WaitForSeconds(seconds);
        enemySoldierMoving.isFollowing = true;
        enemySoldier.enemyRangeSpeed = enemies.fireSpeed;
        enemySoldier.fireRate = enemies.fireRate;
    }

    void ChooseRandomAbility(int random, int maxSpawns, float bulletSpeedMulti)
    {
        switch (random)
        {
            case 1: 
                AbilityOneBingus(maxSpawns);
                break;
            case 2:
                StartCoroutine(AbilityParryBingus());
                break;
            case 3:
                StartCoroutine(AbilityTeleportBingus(5f, bulletSpeedMulti, 2f, false));
                break;
            case 4:
                StartCoroutine(AbilityShootBingus(bulletSpeedMulti, 2f));
                break;
            case 5:
                AbilityOneBingus(maxSpawns);
                break;
            default: break;
        }
    }

    void ChooseRandomAbility2(int random, int maxSpawns, float bulletSpeedMulti)
    {
        switch (random)
        {
            case 1:
                AbilityOneBingus(maxSpawns);
                break;
            case 2:
                AbilityOneBingus(maxSpawns);
                break;
            case 3:
                Regenerate(maxFlowers);
                break;
            case 4:
                StartCoroutine(AbilityShootBingus(bulletSpeedMulti, 2f));
                break;
            case 5:
                StartCoroutine(AbilityTeleportBingus(4f, bulletSpeedMulti, 2f, true));
                break;
            default: break;
        }
    }

    void Regenerate(int flowerMaxSpawns)
    {

        if (numberOfFlowers <= flowerMaxSpawns)
        {
            int flowersToSpawn = Random.Range(2, flowerMaxSpawns);
            for (int i = 0; i < flowersToSpawn; i++)
            {
                Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * Random.Range(2, 7);
                Instantiate(flowerHeal, spawnPosition, Quaternion.identity);
            }
        }
    }

    void HealingFlower(float value)
    {
        if (numberOfFlowers > 0)
        {
            enemySoldier.enemyDMG = 0f;
            enemySoldierBullet.wait = false;
            isHealing = true;
            enemySoldierMoving.isFollowing = false;
            animator.SetBool("Healing", true);
            if (enemyHP.currentSoldierHp < enemySoldier.maxEnemyHP)
            {
                enemyHP.currentSoldierHp += (value / 10) * Time.deltaTime;
                enemyHP.currentSoldierHp = Mathf.Min(enemyHP.currentSoldierHp, enemySoldier.maxEnemyHP);
            }
        }
        else
        {
            enemySoldier.enemyDMG = (enemies.enemyDamage - 1f);
            animator.SetBool("Healing", false);
            enemySoldierMoving.isFollowing = true;
            enemySoldierBullet.wait = true;
            isHealing = false;
        }
        Debug.Log(enemyHP.currentSoldierHp);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Sword.ToString()) && bingusParry)
        {
            particleParry.Stop();
            if (!playerMovement.isRolling)
            {
                hpBar.currentHp -= enemySoldier.enemyDMG;
            }
            animator.SetTrigger("Counter");
            float angle = Random.Range(0f, 360f);
            gameObject.transform.position = Quaternion.Euler(0f, 0f, angle) * new Vector2(0, 0) + new Vector3(player.transform.position.x, player.transform.position.y); 
        }
        if(collision.CompareTag(ObjectTags.Sword.ToString()) && isHealing)
        {
            enemyHP.currentSoldierHp += playerStats.playerDamage;
        }
    }
}

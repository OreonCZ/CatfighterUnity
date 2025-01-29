using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.EnumTypes;
using UnityEngine.Tilemaps;

public class Lucik : MonoBehaviour
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
    public GameObject turret;
    Laser laser;
    LineRenderer lineRenderer;

    private float abilityCooldown = 3f;
    float abilityTimer = 0f;

    GameObject[] aoe;

    GameObject[] changedTiles;

    SpriteRenderer spriteRenderer;

    public bool transformLucik = false;
    EnemyHP enemyHP;
    public GameObject transformUI;
    Fight fight;
    GameObject firstTransition;

    public Text lucikName;
    string lucikBossName;
    private GameObject[] rays;
    int count;

    int maxRays = 5;

    Camera camera;
    GameObject mainCamera;

    Parry parry;
    Rigidbody2D playerRb;
    Spin spin;

    EnemySoldierBullet enemySoldierBullet;

    public GameObject aoeSlow;
    public GameObject lucikBar;
    public Slider lucikSlider;
    public float barValue;
    public bool hasRedHalo = false;

    public bool canCast = true;

    Vector3 cameraDefaultScale;

    public bool isLucikShooting = false;
    bool isRedHaloRunning = false;

    public ParticleSystem chargeParticle;



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
        playerRb = player.GetComponent<Rigidbody2D>();
        //enemySoldierBullet = GetComponent<EnemySoldierBullet>();

        mainCamera = GameObject.Find("Camera");
        camera = mainCamera.GetComponent<Camera>();
        laser = turret.GetComponent<Laser>();
        lineRenderer = turret.GetComponentInChildren<LineRenderer>();
        spin = turret.GetComponent<Spin>();
        
        lucikSlider.maxValue = 12f;
        barValue = 0f;

        cameraDefaultScale = mainCamera.transform.localScale;

        changedTiles = GameObject.FindGameObjectsWithTag(ObjectTags.LunaChange.ToString());

        //lucikRay.SetActive(false);
    }

    // Update is called once per frame
     void Update()
    {
        rays = GameObject.FindGameObjectsWithTag(ObjectTags.Ray.ToString());
        count = rays.Length;

        LucikPhases();

        if (count >= maxRays)
        {
            DestroyOutcomes();
            foreach (GameObject obj in rays)
            {
                Destroy(obj);
            }
        }
    }

    void DestroyOutcomes()
    {
        abilityTimer = 3f;

        if (!transformLucik)
        {
            animator.SetTrigger("Snap");
            float angle = Random.Range(0f, 360f);
            transform.position = Quaternion.Euler(0f, 0f, angle) * new Vector2(0, 3) + player.transform.position;
        }
        else if (count >= maxRays)
        {
            canCast = false;
            enemySoldierMoving.isFollowing = false;
            StartCoroutine(LucikRay(Random.Range(1f, 5f)));
        }
    }

    private IEnumerator LucikRay(float seconds)
    {
        chargeParticle.Play();
        animator.SetTrigger("Charge");
        yield return new WaitForSeconds(seconds);

        isLucikShooting = true;
        enemySoldier.enemyRangeSpeed = 20f;
        enemySoldier.enemyRangeDMG = 1f;
        enemySoldier.fireRate = 5f;
        chargeParticle.Stop();

        animator.SetTrigger("Shoot");
        yield return new WaitForSeconds(2f);


        isLucikShooting = false;
        if (!hasRedHalo) canCast = true;
        enemySoldierMoving.isFollowing = true;

        ResetEnemyStats();
    }

    void ResetEnemyStats()
    {
        enemySoldier.enemyRangeSpeed = enemies.fireSpeed;
        enemySoldier.enemyRangeDMG = enemies.shootDamage;
    }

    void LucikPhases()
    {
        lucikSlider.value = barValue;

        if (enemyHP.currentSoldierHp > 0)
        {
            if (enemyHP.currentSoldierHp <= (enemySoldier.maxEnemyHP / 2))
            {
                lucikBossName = "Lucik, the Lord of the Upside Down";
                lucikName.text = lucikBossName;
                StartCoroutine(Transformation());
            }

            if (transformLucik)
            {
                LucikAbilities2();
                spin.orbitRadius = Random.Range(1f, 7f);
                if (!isLucikShooting) enemySoldier.fireRate = Random.Range(50f, 100f);

                if (barValue >= lucikSlider.maxValue && !hasRedHalo && !isRedHaloRunning)
                {
                    StartCoroutine(RedHalo());
                }

                if (hasRedHalo)
                {
                    HaloRunning();
                }
            }
            else
            {
                spin.orbitRadius = Random.Range(1f, 5f);
                LucikAbilities();
            }
        }
        else
        {
            enemySoldier.enemyDMG = 0f;
            StartCoroutine(DeadDestroy());
        }
    }

    void HaloRunning()
    {
        foreach (GameObject obj in rays)
        {
            Destroy(obj);
        }
        abilityTimer = 3f;
        enemySoldierMoving.isFollowing = true;

        if (barValue > 0)
        {
            canCast = false;
            foreach (GameObject obj in changedTiles)
            {
                Tilemap tilemap = obj.GetComponent<Tilemap>();
                    tilemap.color = new Color32(255, 60, 60, 120);
            }

            enemySoldier.enemyMovementSpeed = 17f;
            enemySoldier.enemyDMG = playerStats.playerMaxHP;
            barValue -= lucikSlider.maxValue / 10f * Time.deltaTime;
        }
        else
        {
            ResetHaloState();
        }
    }

    void ResetHaloState()
    {
        foreach (GameObject obj in changedTiles)
        {
            Tilemap tilemap = obj.GetComponent<Tilemap>();
                tilemap.color = new Color32(255, 255, 255, 160);
        }

        enemySoldier.enemyMovementSpeed = 1.7f;
        enemySoldier.enemyDMG = enemies.enemyDamage;
        barValue = 0;
        animator.SetBool("Halo", false);
        hasRedHalo = false;
        canCast = true;
    }

    private IEnumerator RedHalo()
    {
        isRedHaloRunning = true;
        animator.SetBool("Halo", false);
        animator.SetTrigger("ChangeHalo");

        foreach (GameObject obj in rays)
        {
            Destroy(obj);
        }

        canCast = false;
        enemySoldierMoving.isFollowing = false;
        yield return new WaitForSeconds(0.7f);

        animator.SetBool("Halo", true);
        hasRedHalo = true;
        isRedHaloRunning = false;
    }


    IEnumerator Transformation()
    {
        if (!transformLucik)
        {
            foreach (GameObject obj in rays)
            {
                Destroy(obj);
            }
            float angle = Random.Range(0f, 360f);
            gameObject.transform.position = Quaternion.Euler(0f, 0f, angle) * new Vector2(0, 5) + new Vector3(player.transform.position.x, player.transform.position.y);
            animator.SetBool("Transform", true);
            animator.SetTrigger("Change");
            playerMovement.canWalk = false;
            fight.canAttack = false;
            enemySoldier.enemyRangeDMG = 0f;
            enemySoldier.enemyRangeSpeed = 0f;
            enemySoldier.enemyDMG = 0f;
            //enemySoldierBullet.wait = false;
            transformUI.SetActive(true);
            enemySoldierMoving.isFollowing = false;
            enemySoldier.enemyRangeSpeed = 30f;

            yield return new WaitForSeconds(3.25f);
            foreach (GameObject obj in changedTiles)
            {
                Tilemap tilemap = obj.GetComponent<Tilemap>();
                tilemap.color = new Color32(255, 255, 255, 160);
            }

            maxRays = 6;

            //enemySoldierBullet.wait = true;
            lucikBar.SetActive(true);
            enemySoldierMoving.isFollowing = true;

            enemySoldier.enemyMovementSpeed = 1.7f;
            enemySoldier.enemyDMG = enemies.enemyDamage;
            enemySoldier.enemyRangeDMG = enemies.shootDamage;
            transformLucik = true;
            transformUI.SetActive(false);
            fight.canAttack = true;
            playerMovement.canWalk = true;
            firstTransition.SetActive(true);

        }
    }

    IEnumerator DeadDestroy()
    {
        animator.SetBool("Ko", true);
        yield return new WaitForSeconds(0.43f);
        Destroy(gameObject);
    }
    void LucikAbilities()
    {
        abilityTimer -= Time.deltaTime;
        if (abilityTimer <= 0f && canCast)
        {
            ChooseRandomAbility(Random.Range(1, 6));
            abilityTimer = abilityCooldown;
        }
    }
    void LucikAbilities2()
    {
        abilityTimer -= Time.deltaTime;
        if (abilityTimer <= 0f && canCast)
        {
            ChooseRandomAbility2(Random.Range(1, 6));
            abilityTimer = abilityCooldown;
        }
    }


    IEnumerator Snap(float seconds)
    {
        enemySoldierMoving.isFollowing = false;
        animator.SetTrigger("Snap");
        yield return new WaitForSeconds(seconds);
        Vector2 enemyPosition = gameObject.transform.position;
        float angle = Random.Range(0f, 360f);
        gameObject.transform.position = Quaternion.Euler(0f, 0f, angle) * new Vector2(0, 3) + new Vector3(player.transform.position.x, player.transform.position.y);
        player.transform.position = enemyPosition;
        if(!isLucikShooting) enemySoldierMoving.isFollowing = true;
    }

    void PushPlayer(float pushForce)
    {
        if (player != null && playerRb != null)
        {
            Vector2 direction = (transform.position - player.transform.position).normalized;

            playerRb.AddForce(direction * pushForce, ForceMode2D.Impulse);
        }
    }

    IEnumerator Control(float seconds)
    {
        animator.SetTrigger("Control");
        playerMovement.RandomizeControls();
        if (transformLucik) PushPlayer(200f);

        yield return new WaitForSeconds(seconds);
        playerMovement.ResetControls();
    }

    IEnumerator Summon(float seconds, float speed, bool animation)
    {
        if(animation) animator.SetTrigger("Summon");
        Instantiate(turret);
        enemySoldier.enemyRangeSpeed = speed;
        yield return new WaitForSeconds(seconds);
        enemySoldier.enemyRangeSpeed = enemies.fireSpeed;

    }

    IEnumerator BiggerRay(float seconds, float damage, bool animation)
    {
        if(animation) animator.SetTrigger("Praise");
        enemySoldier.enemyRangeDMG = damage;
        yield return new WaitForSeconds(seconds);
        enemySoldier.enemyRangeDMG = enemies.shootDamage;
        if(enemyHP.currentSoldierHp + playerStats.playerDamage <= enemySoldier.maxEnemyHP)
        {
            enemyHP.currentSoldierHp += playerStats.playerDamage;
        }

    }

    IEnumerator Aoe(float seconds)
    {
        enemySoldierMoving.isFollowing = false;
        aoeSlow.SetActive(true);
        animator.SetTrigger("Aoe");
        yield return new WaitForSeconds(seconds);
        playerMovement.walking = true;
        if(!isLucikShooting)enemySoldierMoving.isFollowing = true;
    }

    IEnumerator FlipCamera(float seconds, int chance)
    {
        int chanceInt = Random.Range(0, chance);

        if(chanceInt == 0)
        {
            Debug.LogError("GGGGG");
            bool flipHorizontally = Random.value > 0.5f;
            bool flipVertically = Random.value > 0.5f;

            Vector3 flippedScale = cameraDefaultScale;
            if (flipHorizontally) flippedScale.x = -cameraDefaultScale.x;
            if (flipVertically) flippedScale.y = -cameraDefaultScale.y;

            mainCamera.transform.localScale = flippedScale;
            yield return new WaitForSeconds(seconds);

            mainCamera.transform.localScale = cameraDefaultScale;
        }
    }


    void ChooseRandomAbility(int random)
    {
        switch (random)
        {
            case 1:
                StartCoroutine(BiggerRay(2f,  0.05f, true));
                StartCoroutine(Summon(2f, 2f, false));
                break;
            case 2:
                StartCoroutine(Control(1));
                StartCoroutine(Summon(2f, 2f, false));
                break;
            case 3:
                StartCoroutine(Summon(2f, 6f, true));
                break;
            case 4:
                StartCoroutine(Summon(2f, 4f, true));
                break;
            case 5:
                StartCoroutine(BiggerRay(2f, 0.04f, false));
                StartCoroutine(Snap(0.5f));
                StartCoroutine(Summon(2f, 1f, false));
                break;
        }
    }
    void ChooseRandomAbility2(int random)
    {
        switch (random)
        {
            case 1:
                StartCoroutine(Control(1.5f));
                StartCoroutine(Summon(2f, 5f, false));
                //StartCoroutine(FlipCamera(3f, 5));
                break;
            case 2:
                StartCoroutine(Control(1.5f));
                StartCoroutine(BiggerRay(2f, 0.06f, false));
                StartCoroutine(Summon(2f, 3f, false));
                //StartCoroutine(FlipCamera(3f, 5));

                break;
            case 3:
                //StartCoroutine(Control(1.5f));
                StartCoroutine(Aoe(1.5f));
                StartCoroutine(Summon(2f, 4f, false));
                //StartCoroutine(FlipCamera(3f, 5));

                break;
            case 4:
                StartCoroutine(BiggerRay(2f, 0.06f, false));
                StartCoroutine(Snap(0.5f));
                StartCoroutine(Summon(2f, 5f, false));
                //StartCoroutine(FlipCamera(3f, 5));
                break;
            case 5:
                StartCoroutine(Snap(0.5f));
                StartCoroutine(Summon(2f, 12f, false));
                //StartCoroutine(FlipCamera(3f, 5));
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.EnumTypes;

public class Brucha : MonoBehaviour
{
    EnemySoldier enemySoldier;
    EnemySoldierMoving enemySoldierMoving;
    EnemyHP enemyHP;
    GameObject player;
    GameObject[] vanishObjects;
    public GameObject bruchaBullet;
    public bool transformBrucha = false;
    Animator animator;
    public Text bruchaName;
    string bruchaBossName;
    bool bossIsParrying;
    public GameObject counter;
    ParticleSystem particleBrucha;
    ParticleSystem particleTP;
    public static bool bulletTouchedPlayer = false;
    PlayerStats playerStats;
    HpBar hpBar;
    Movement playerMovement;
    public Enemies enemies;

    // Start is called before the first frame update
    void Start()
    {
        vanishObjects = GameObject.FindGameObjectsWithTag(ObjectTags.BruchaVanish.ToString());
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        enemySoldier = GetComponent<EnemySoldier>();
        enemySoldierMoving = GetComponent<EnemySoldierMoving>();
        enemyHP = GetComponent<EnemyHP>();
        animator = GetComponent<Animator>();
        particleBrucha = GameObject.Find("ParticlesBrucha").GetComponent<ParticleSystem>();
        hpBar = player.GetComponent<HpBar>();
        playerMovement = player.GetComponent<Movement>();
        particleTP = GameObject.Find("ParticlesTP").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        BruchaUpdate();
        BruchaCounterActive();
        
    }

    void BruchaCounterActive()
    {
        if(bulletTouchedPlayer && transformBrucha)
        {
            StartCoroutine(SpeedUp(30f));
            counter.SetActive(true);
            if(enemyHP.currentSoldierHp <= 0f)
            {
                counter.SetActive(false);
            }
        }
        else if(bulletTouchedPlayer && !transformBrucha)
        {
            StartCoroutine(SpeedUp(20f));
        }
        else
        {
            counter.SetActive(false);
        }
    }
    IEnumerator SpeedUp(float value)
    {
        particleTP.Play();
        enemySoldier.enemyMovementSpeed = value;
        yield return new WaitForSeconds(0.3f);
        enemySoldier.enemyMovementSpeed = enemies.enemySpeed;
        
    }

    void BruchaUpdate()
    {
        if (enemyHP.currentSoldierHp <= (enemySoldier.maxEnemyHP / 2))
        {
            StartCoroutine(Transformation());
            
            bruchaBossName = "Brucha, the Lost Catfighter";
            bruchaName.text = bruchaBossName;
            bruchaBullet.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        else
        {
            bruchaBullet.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    IEnumerator Transformation()
    {
        if (!transformBrucha)
        {
            particleBrucha.Play();
            animator.SetBool("isTransforming", true);
            animator.SetTrigger("isTransform");
            animator.SetBool("Idle", false);
            enemySoldierMoving.isFollowing = false;
            enemySoldier.enemyRangeSpeed = 30f;
            yield return new WaitForSeconds(1f);
            enemySoldierMoving.isFollowing = true;
            enemySoldier.enemyRangeSpeed = 60f;
            enemySoldier.enemyMovementSpeed = 4f;
            enemySoldier.enemyDMG = 3.2f;
            foreach (GameObject obj in vanishObjects)
            {
                obj.SetActive(false);
            }
            transformBrucha = true;
            animator.SetBool("isTransforming", false);
            enemyHP.currentSoldierHp = enemySoldier.maxEnemyHP;
        }
    }

    IEnumerator Counter()
    {
        enemySoldier.enemyMovementSpeed = 14f;
        counter.SetActive(false);
        animator.SetTrigger("Counter");
        animator.SetBool("isCountering", true);
        yield return new WaitForSeconds(1f);
        if (!playerMovement.isRolling)
        {
            hpBar.currentHp -= enemySoldier.enemyDMG;
        }
        animator.SetBool("isCountering", false);
        enemySoldier.enemyMovementSpeed = 4f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Sword.ToString()) && transformBrucha && !enemyHP.isDefeated)
        {
            particleTP.Play();
            float angle = Random.Range(0f, 360f);
            if (bulletTouchedPlayer)
            {
                gameObject.transform.position = Quaternion.Euler(0f, 0f, angle) * new Vector2(0, 0) + new Vector3(player.transform.position.x, player.transform.position.y);
                StartCoroutine(Counter());
            }
            else
            {
                gameObject.transform.position = Quaternion.Euler(0f, 0f, angle) * new Vector2(Random.Range(2, 4), 0) + new Vector3(player.transform.position.x, player.transform.position.y);
            }
        }
    }
}

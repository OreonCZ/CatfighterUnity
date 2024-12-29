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
    GameObject grid;
    GameObject[] vanishObjects;
    public GameObject bruchaBullet;
    public bool transformBrucha = false;
    Animator animator;
    public Text bruchaName;
    string bruchaBossName;
    bool bossIsParrying;
    public GameObject counter;
    ParticleSystem particleBrucha;

    // Start is called before the first frame update
    void Start()
    {
        vanishObjects = GameObject.FindGameObjectsWithTag(ObjectTags.BruchaVanish.ToString());
        grid = GameObject.Find("Grid");
        enemySoldier = GetComponent<EnemySoldier>();
        enemySoldierMoving = GetComponent<EnemySoldierMoving>();
        enemyHP = GetComponent<EnemyHP>();
        animator = GetComponent<Animator>();
        particleBrucha = GetComponentInChildren<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemySoldierShoot enemySoldierShoot = bruchaBullet.GetComponent<EnemySoldierShoot>();

        BruchaUpdate();
        if (enemySoldierShoot.bruchaBulletTouched)
        {
            counter.SetActive(true);
        }
        else
        {
            counter.SetActive(false);
        }
        if (bruchaBullet == null)
        {
            Debug.LogError("bruchaBullet is not assigned in the Brucha script.");
        }
        else if (bruchaBullet.GetComponent<EnemySoldierShoot>() == null)
        {
            Debug.LogError("bruchaBullet does not have EnemySoldierShoot component.");
        }
    }

    void BruchaUpdate()
    {
        if (enemyHP.currentSoldierHp <= (enemySoldier.maxEnemyHP / 2))
        {
            StartCoroutine(Transformation());
            
            bruchaBossName = "Brucha, the Lost Catfighter";
            bruchaName.text = bruchaBossName;
            bruchaBullet.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
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
            enemySoldier.enemyRangeDMG = 2;
            foreach (GameObject obj in vanishObjects)
            {
                obj.SetActive(false);
            }
            transformBrucha = true;
            animator.SetBool("isTransforming", false);
            enemyHP.currentSoldierHp = enemySoldier.maxEnemyHP;
        }
    }
}

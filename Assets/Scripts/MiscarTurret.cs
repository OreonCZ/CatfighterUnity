using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscarTurret : MonoBehaviour
{
    GameObject miscar;
    Transform target;
    float orbitRadius = 2.5f;
    float orbitSpeed;
    float targetRadius;
    float radiusChangeDuration = 2.5f;
    float radiusChangeTimer = 0.0f;
    EnemyHP enemyHP;
    EnemySoldier enemySoldier;
    Animator animator;
    ParticleSystem particle;
    EnemySoldierMoving enemySoldierMoving;
    private bool isCoroutineRunning = false;
    Transform fireTransform;
    public Enemies enemies;

    private float angle = 0.0f;

    void Start()
    {
        miscar = GameObject.Find("Miscar");
        target = miscar.GetComponent<Transform>();
        enemyHP = miscar.GetComponent<EnemyHP>();
        enemySoldier = miscar.GetComponent<EnemySoldier>();

        orbitSpeed = enemySoldier.enemyRangeSpeed;
        animator = miscar.GetComponent<Animator>();
        enemySoldierMoving = miscar.GetComponent<EnemySoldierMoving>();
        particle = miscar.GetComponentInChildren<ParticleSystem>();
        fireTransform = this.gameObject.GetComponent<Transform>();
        particle.Stop();
    }

    void Update()
    {
        Spin();
        MiscarPhases();
    }
    void MiscarPhases()
    {
        if (enemyHP.currentSoldierHp > (enemySoldier.maxEnemyHP / 4) && enemyHP.currentSoldierHp <= (enemySoldier.maxEnemyHP / 2))
        {
            orbitSpeed = enemySoldier.enemyRangeSpeed * 1.7f;
            particle.Play();
            UpdateRadius(6f);
            enemySoldier.enemyMovementSpeed = 0.5f;
            animator.SetBool("isReloading", true);
            return;
        }
        else if (enemyHP.currentSoldierHp > 0f && enemyHP.currentSoldierHp <= (enemySoldier.maxEnemyHP / 4))
        {
            orbitSpeed = enemySoldier.enemyRangeSpeed * 3f;
            particle.Play();
            UpdateRadius(10f);
            enemySoldier.fireRate = enemies.fireRate + 1f;
            enemySoldier.enemyMovementSpeed = 0.5f;
            animator.SetBool("isReloading", true);
            fireTransform.localScale = new Vector3(1.3f, 1.3f);
            Debug.Log("pome");
            return;
        }
        else if(enemyHP.currentSoldierHp <= 0f)
        {
            particle.Stop();
            animator.SetBool("isReloading", false);
            Debug.Log("pomeeeeeeeeeeeeeeeee");
        }
    }

    void Spin()
    {

        if (target == null)
        {
            Debug.LogWarning("No target assigned for orbiting!");
            return;
        }

        angle += orbitSpeed * Time.deltaTime;

        float angleRad = angle * Mathf.Deg2Rad;

        float x = target.position.x + Mathf.Cos(angleRad) * orbitRadius;
        float y = target.position.y + Mathf.Sin(angleRad) * orbitRadius;

        transform.position = new Vector2(x, y);
    }
    void UpdateRadius(float maxRadiusChange)
    {
        radiusChangeTimer += Time.deltaTime;

        orbitRadius = Mathf.Lerp(orbitRadius, targetRadius, Time.deltaTime / radiusChangeDuration);

        if (radiusChangeTimer >= radiusChangeDuration)
        {
            targetRadius = Random.Range(1.0f, maxRadiusChange);
            radiusChangeTimer = 0.0f;
        }
    }

}

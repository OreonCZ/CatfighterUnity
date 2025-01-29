using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class Spin : MonoBehaviour
{
    float fireRate;
    HpBar hpbar;
    EnemySoldier enemySoldier;
    EnemyHP enemyHP;
    GameObject enemy;

    Transform target;
    public float orbitRadius = 3.0f;
    //public float orbitSpeed = 50.0f;
    private float angle = 0f;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag(ObjectTags.Enemy.ToString());
        target = enemy.GetComponent<Transform>();
        enemyHP = enemy.GetComponent<EnemyHP>();
        enemySoldier = enemy.GetComponent<EnemySoldier>();
    }

    void Update()
    {
        if (target != null)
        {
            SpinAroundTarget();
        }
    }

    void SpinAroundTarget()
    {

        angle += enemySoldier.fireRate * Time.deltaTime;

        float angleRad = angle * Mathf.Deg2Rad;

        float x = target.position.x + Mathf.Cos(angleRad) * orbitRadius;
        float y = target.position.y + Mathf.Sin(angleRad) * orbitRadius;

        transform.position = new Vector2(x, y);
    }

}

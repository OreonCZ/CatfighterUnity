using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class OscarTurret : MonoBehaviour
{
    public GameObject projectile;
    public Transform playerPosition;
    GameObject player;
    float fireRate;
    float nextFire = 0f;
    HpBar hpbar;
    EnemySoldier enemySoldier;
    EnemyHP enemyHP;
    public GameObject oscar;
    Oscar oscarScript;

    public Transform target;
    public float orbitRadius = 3.0f;
    public float orbitSpeed = 50.0f;
    private float angle = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        hpbar = player.GetComponent<HpBar>();
        enemyHP = oscar.GetComponent<EnemyHP>();
        enemySoldier = oscar.GetComponent<EnemySoldier>();
        oscarScript = oscar.GetComponent<Oscar>();

    }

    void Update()
    {
        if (target != null)
        {
            SpinAroundTarget();
        }

        // Fire projectiles
        if (Time.time > nextFire)
        {
            if (hpbar.currentHp > 0 && oscarScript.oscarCanShoot)
            {
                Fire();
            }
            nextFire = Time.time + 1f / Mathf.Max(1f, 0.1f);
        }
    }

    void SpinAroundTarget()
    {
        angle += orbitSpeed * Time.deltaTime;

        float angleRad = angle * Mathf.Deg2Rad;

        float x = target.position.x + Mathf.Cos(angleRad) * orbitRadius;
        float y = target.position.y + Mathf.Sin(angleRad) * orbitRadius;

        transform.position = new Vector2(x, y);
    }

    void Fire()
    {
        Vector2 direction = (playerPosition.position - transform.position).normalized;
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        OscarBulletShoot bulletComponent = bullet.GetComponent<OscarBulletShoot>();
        if (bulletComponent != null)
        {
            bulletComponent.direction = direction;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class OscarBulletShoot : MonoBehaviour
{
    //float moveSpeed = 7f;
    public Vector2 direction;
    public bool playerHit;
    EnemyHP enemyHpScript;
    Movement playerMScript;
    public Enemies enemies;
    HpBar hpBar;
    EnemySoldier enemySoldier;
    public float projectileSpeed = 4f;
    Oscar oscarScript;

    void Start()
    {
        GameObject enemy = GameObject.FindWithTag(ObjectTags.Enemy.ToString());
        enemyHpScript = enemy.GetComponent<EnemyHP>();
        oscarScript = enemy.GetComponent<Oscar>();
        GameObject player = GameObject.FindWithTag(ObjectTags.Player.ToString());
        playerMScript = player.GetComponent<Movement>();
        hpBar = player.GetComponent<HpBar>();
        enemySoldier = enemy.GetComponent<EnemySoldier>();

    }
    void Update()
    {
        if (oscarScript.oscarCanShoot)
        {
            Projectile();
        }
        if (enemyHpScript.currentSoldierHp <= 0)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, (enemySoldier.destroyProjectile - 2f));
    }

    void Projectile()
    {
        transform.Translate(direction * projectileSpeed * Time.deltaTime);
    }
    void PlayerHit(GameObject Player)
    {
        EnemyProjectileDMG enemyProjectileDMG = Player.GetComponent<EnemyProjectileDMG>();
        enemyProjectileDMG.OnHitDamage(enemySoldier.enemyRangeDMG);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !playerMScript.isRolling)
        {
            PlayerHit(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && playerMScript.isRolling)
        {
            return;
        }
    }
}
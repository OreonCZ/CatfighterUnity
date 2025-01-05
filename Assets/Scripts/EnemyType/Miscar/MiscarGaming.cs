using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscarGaming : MonoBehaviour
{
    public GameObject projectile;
    public Transform playerPosition;
    public float fireRate;
    public float nextFire = 0f;
    public HpBar hpbar;
    public Enemies enemies;
    public EnemyShoot enemyShoot;
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            if (enemy.currentEnemyHP == 1)
            {
                Fire();
            }
            nextFire = Time.time + 1f / enemy.fireRate;
        }
        if(hpbar.currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Fire()
    {
        Vector2 direction = (playerPosition.position - transform.position).normalized;
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        EnemyShoot bulletComponent = bullet.GetComponent<EnemyShoot>();
        if (bulletComponent != null)
        {
            bulletComponent.direction = direction;
        }
    }
}

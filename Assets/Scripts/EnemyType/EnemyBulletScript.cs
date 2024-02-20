using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
	public GameObject projectile;
	public Transform playerPosition;
	public float fireRate;
	public float nextFire = 0f;
	public HpBar hpbar;
	public Enemies enemies;
    public EnemyShoot enemyShoot;
	public Enemy enemy;

    // Use this for initialization
    void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
        if (Time.time > nextFire)
        {
			if(enemy.currentEnemyHP > 0) 
			{
			Fire();
			}
			nextFire = Time.time + 1f / enemy.fireRate;
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

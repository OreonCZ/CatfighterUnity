using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscarTurret : MonoBehaviour
{
	public GameObject projectile;
	public Transform playerPosition;
	public float fireRate;
	public float nextFire = 0f;
	public HpBar hpbar;
	public Enemies enemies;
	public OscarBulletShoot enemyShoot;
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
			if (enemy.currentEnemyHP < 7 && hpbar.currentHp > 0)
			{
				Fire();
			}
			nextFire = Time.time + 1f / (enemy.fireRate - 2.8f);
			Debug.Log("INANSE");
		}
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

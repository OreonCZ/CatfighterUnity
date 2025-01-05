using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscarBulletScript : MonoBehaviour
{
	public GameObject projectile;
	public Transform playerPosition;
	public float nextFire = 0f;
	public HpBar hpbar;
	public Enemies enemies;
	public EnemyShoot enemyShoot;
	public Enemy enemy;
	bool wait = false;
	public Miscar miscar;
	public Vector2 direction;
	public bool canShoot = true;

	void Start()
	{
		StartCoroutine(WaitForTransition());
	}

	// Update is called once per frame
	void Update()
	{
		if (canShoot)
        {
			if (Time.time > nextFire && wait)
			{
				if (enemy.currentEnemyHP > 0)
				{
					Fire();
				}
				nextFire = Time.time + 1f / enemy.fireRate;
			}
		}
	}

	IEnumerator WaitForTransition()
	{
		yield return new WaitForSeconds(1f);
		wait = true;
	}

	public void Fire()
	{
		direction = (playerPosition.position - transform.position).normalized;
		GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
		EnemyShoot bulletComponent = bullet.GetComponent<EnemyShoot>();
		if (bulletComponent != null)
		{
			bulletComponent.direction = direction;
		}
	}
}

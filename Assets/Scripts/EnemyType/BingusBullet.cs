using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BingusBullet : MonoBehaviour
{
	public GameObject projectile;
	public Transform playerPosition;
	public float fireRate;
	public float nextFire = 0f;
	public HpBar hpbar;
	public Enemies enemies;
	public BingusShoot bingusShoot;
	public Enemy enemy;
	bool wait = false;

	// Use this for initialization
	void Start()
	{
		StartCoroutine(WaitForTransition());
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.time > nextFire && wait)
		{
			if (enemy.currentEnemyHP > 1)
			{
				Fire();
			}
			nextFire = Time.time + 1f / enemy.fireRate;
		}
	}
	IEnumerator WaitForTransition()
	{
		yield return new WaitForSeconds(2f);
		wait = true;
	}


	void Fire()
	{
		Vector2 direction = (playerPosition.position - transform.position).normalized;
		GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
		BingusShoot bulletComponent = bullet.GetComponent<BingusShoot>();
		if (bulletComponent != null)
		{
			bulletComponent.direction = direction;
		}
	}
}

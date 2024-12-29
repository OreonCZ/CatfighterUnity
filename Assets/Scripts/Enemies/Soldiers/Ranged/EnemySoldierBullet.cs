using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class EnemySoldierBullet : MonoBehaviour
{
	public GameObject projectile;
	Transform playerPosition;
	public float nextFire = 0f;
	HpBar hpbar;
	public Enemies enemies;
	//EnemyShoot enemyShoot;
	EnemySoldier enemySoldier;
	EnemySoldierHP enemySoldierHP;
	EnemyHP enemyHP;
	GameObject oscarArea;
	private int spawnCount = 1;

	bool enemyShootBullet;

	public bool wait = false;

	void Start()
	{
		GameObject player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
		hpbar = player.GetComponent<HpBar>();
		playerPosition = player.GetComponent<Transform>();

		enemySoldier = GetComponent<EnemySoldier>();
		enemySoldierHP = GetComponent<EnemySoldierHP>();
		enemyHP = GetComponent<EnemyHP>();
		oscarArea = GameObject.Find("CoinSpawnArea");


		//enemyRangerAttack = GetComponentInChildren<EnemyRangerAttack>();

		StartCoroutine(WaitForTransition());
	}

	void DiffRangeEnemy()
    {
		if ("Fiend" == enemySoldier.catName)
		{
			EnemyBulletAttack enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
			if (Time.time > nextFire && wait)
			{
				if (enemySoldierHP.currentSoldierHp > 0 && enemyBulletAttack.soldierAttacks && enemyBulletAttack.canShoot)
				{
					Fire();
				}
				nextFire = Time.time + 1f / enemySoldier.fireRate;
			}
		}

		if ("Ranger" == enemySoldier.catName)
		{
			EnemyRangerAttack enemyRangerAttack = GetComponentInChildren<EnemyRangerAttack>();
			if (Time.time > nextFire && wait)
			{
				if (enemySoldierHP.currentSoldierHp > 0 && enemyRangerAttack.soldierAttacks)
				{
					Fire();
				}
				nextFire = Time.time + 1f / enemySoldier.fireRate;
			}
		}
		if ("Intruder" == enemySoldier.catName)
		{
			EnemyBulletAttack enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
			if (Time.time > nextFire && wait)
			{
				if (enemySoldierHP.currentSoldierHp > 0 && enemyBulletAttack.soldierAttacks)
				{
					Fire();
				}
				nextFire = Time.time + 1f / enemySoldier.fireRate;
			}
		}
		if ("Cultist" == enemySoldier.catName)
		{
			EnemyBulletAttack enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
			if (Time.time > nextFire && wait)
			{
				if (enemySoldierHP.currentSoldierHp > 0 && enemyBulletAttack.soldierAttacks)
				{
					Fire();
				}
				nextFire = Time.time + 1f / enemySoldier.fireRate;
			}
		}
		if ("Ninja" == enemySoldier.catName)
		{
			EnemyRangerAttack enemyRangerAttack = GetComponentInChildren<EnemyRangerAttack>();
			if (Time.time > nextFire)
			{
				if (enemySoldierHP.currentSoldierHp > 0 && enemyRangerAttack.soldierAttacks)
				{
					Fire();
					StartCoroutine(DoubleShoot());
				}
				nextFire = Time.time + 1f / enemySoldier.fireRate;
			}
		}
		if ("Yuki" == enemySoldier.catName)
		{
			EnemyBulletAttack enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
			if (Time.time > nextFire && wait)
			{
				if (enemyHP.currentSoldierHp > 0 && enemyBulletAttack.soldierAttacks)
				{
					Fire();
				}
				nextFire = Time.time + 1f / enemySoldier.fireRate;
			}
		}
		if ("Bingus" == enemySoldier.catName)
		{
			EnemyBulletAttack enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
			if (Time.time > nextFire && wait)
			{
				if (enemyHP.currentSoldierHp > 0 && enemyBulletAttack.soldierAttacks)
				{
					Fire();
				}
				nextFire = Time.time + 1f / enemySoldier.fireRate;
			}
		}
		if ("Miscar" == enemySoldier.catName)
		{
			EnemyBulletAttack enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
			if (Time.time > nextFire && wait)
			{
				if (enemyHP.currentSoldierHp > 0 && enemyBulletAttack.soldierAttacks)
				{
					Fire();
				}
				nextFire = Time.time + 1f / enemySoldier.fireRate;
			}
		}
		if ("Oscar" == enemySoldier.catName)
		{
			EnemyBulletAttack enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
			if (Time.time > nextFire && wait)
			{
				if (enemyHP.currentSoldierHp > 0 && enemyBulletAttack.soldierAttacks)
				{
					Fire();
				}
				nextFire = Time.time + 1f / enemySoldier.fireRate;
			}
		}
		if ("Brucha" == enemySoldier.catName)
		{
			EnemyBulletAttack enemyBulletAttack = GetComponentInChildren<EnemyBulletAttack>();
			if (Time.time > nextFire && wait)
			{
				if (enemyHP.currentSoldierHp > 0 && enemyBulletAttack.soldierAttacks)
				{
					Fire();
				}
				nextFire = Time.time + 1f / enemySoldier.fireRate;
			}
		}
	}
	// Update is called once per frame
	void Update()
	{
		DiffRangeEnemy();
	}

	IEnumerator WaitForTransition()
	{
		yield return new WaitForSeconds(0.75f);
		wait = true;
	}

	void Fire()
	{	
		
		if("Intruder" == enemySoldier.catName || "Bingus" == enemySoldier.catName)
		{
			Vector2 direction = (playerPosition.position - transform.position).normalized;
			GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
			EnemyIntruderShoot bulletComponent = bullet.GetComponent<EnemyIntruderShoot>();
			bulletComponent.EnemyInitialization(this.gameObject);
			if (bulletComponent != null)
			{
				bulletComponent.direction = direction;
				bulletComponent.enemy = gameObject;
			}
		}
		else if ("Oscar" == enemySoldier.catName)
        {
			CircleCollider2D collider = oscarArea.GetComponent<CircleCollider2D>();
			for (int i = 0; i < spawnCount; i++)
			{
				Vector2 center = collider.bounds.center;
				float radius = collider.radius * oscarArea.transform.localScale.x;

				Vector2 randomPosition = center + Random.insideUnitCircle * radius;

				Vector2 direction = (playerPosition.position - transform.position).normalized;
				GameObject bullet = Instantiate(projectile, randomPosition, Quaternion.identity);
				EnemySoldierShoot bulletComponent = bullet.GetComponent<EnemySoldierShoot>();

				if (bulletComponent != null)
				{
					bulletComponent.direction = direction;
					bulletComponent.enemy = gameObject;
					bulletComponent.EnemyInitialization(this.gameObject);
				}
			}
		}
	
        else
        {
			Vector2 direction = (playerPosition.position - transform.position).normalized;
			GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
			EnemySoldierShoot bulletComponent = bullet.GetComponent<EnemySoldierShoot>();
			bulletComponent.EnemyInitialization(this.gameObject);
			if (bulletComponent != null)
			{
				bulletComponent.direction = direction;
			}
		}

	}

	IEnumerator DoubleShoot()
    {
		yield return new WaitForSeconds(0.3f);
		Fire();
	}
}

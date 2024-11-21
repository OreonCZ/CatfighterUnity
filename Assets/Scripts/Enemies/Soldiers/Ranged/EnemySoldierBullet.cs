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
	EnemyRangerAttack enemyRangerAttack;

	bool wait = false;

	void Start()
	{
		GameObject player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
		hpbar = player.GetComponent<HpBar>();
		playerPosition = player.GetComponent<Transform>();

		enemySoldier = GetComponent<EnemySoldier>();
		enemySoldierHP = GetComponent<EnemySoldierHP>();
		enemyRangerAttack = gameObject.transform.GetComponentInChildren<EnemyRangerAttack>();

		StartCoroutine(WaitForTransition());
	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log(playerPosition.position);
		if (Time.time > nextFire && wait && enemyRangerAttack.isShooting)
		{
			if (enemySoldierHP.currentSoldierHp > 0)
			{
				Fire();
			}
			nextFire = Time.time + 1f / enemySoldier.fireRate;
		}
	}

	IEnumerator WaitForTransition()
	{
		yield return new WaitForSeconds(0.75f);
		wait = true;
	}

	void Fire()
	{
		Vector2 direction = (playerPosition.position - transform.position).normalized;
		GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
		EnemySoldierShoot bulletComponent = bullet.GetComponent<EnemySoldierShoot>();
		if (bulletComponent != null)
		{
			bulletComponent.direction = direction;
		}
	}
}

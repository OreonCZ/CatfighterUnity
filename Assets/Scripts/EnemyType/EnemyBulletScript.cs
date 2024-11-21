using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class EnemyBulletScript : MonoBehaviour
{
	public GameObject projectile;
	Transform playerPosition;
	public float nextFire = 0f;
	public HpBar hpbar;
	public Enemies enemies;
    public EnemyShoot enemyShoot;
	public Enemy enemy;
	bool wait = false;

    void Start()
	{
		GameObject player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
		hpbar = player.GetComponent<HpBar>();
		StartCoroutine(WaitForTransition());
	}

	// Update is called once per frame
	void Update()
	{
        if (Time.time > nextFire && wait)
        {
			if(enemy.currentEnemyHP > 0) 
			{
			Fire();
			}
			nextFire = Time.time + 1f / enemy.fireRate;
		}
	}

	IEnumerator WaitForTransition()
    {
		yield return new WaitForSeconds(1f);
		wait = true;
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

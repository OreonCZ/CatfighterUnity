using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
	public GameObject projectile;
	public Transform playerPosition;
	public float nextFire = 0f;
	public HpBar hpbar;
	public Enemies enemies;
    public EnemyShoot enemyShoot;
	public Enemy enemy;
	bool wait = false;
	public Yuki yuki;

    void Start()
	{
		StartCoroutine(WaitForTransition());
	}

	// Update is called once per frame
	void Update()
	{
        if (Time.time > nextFire && wait)
        {
			if(enemy.currentEnemyHP > 0 && yuki.canShoot) 
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

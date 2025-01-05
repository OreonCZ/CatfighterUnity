using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class BingusSpeedUp : MonoBehaviour
{
    EnemySoldier enemySoldier;
    public GameObject trail;
    GameObject enemy;
    SpriteRenderer spriteRenderer;
    public Enemies enemies;
    public ParticleSystem particleSpawn;
    public GameObject particle;
    EnemyHP enemyHP;
    public bool bingusInArea;
    // Start is called before the first frame update
    void Start()
    {
        enemySoldier = GetComponentInParent<EnemySoldier>();
        enemy = transform.parent.gameObject;
        spriteRenderer = enemy.GetComponent<SpriteRenderer>();
        enemyHP = enemy.GetComponent<EnemyHP>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHP.currentSoldierHp <= 0)
        {
            spriteRenderer.color = new Color32(255, 255, 255, 255);
            particle.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()))
        {
            bingusInArea = true;
            trail.SetActive(false);
            spriteRenderer.color = new Color32(255, 255, 255, 255);
            enemySoldier.enemyMovementSpeed = 2.5f;
            particleSpawn.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTags.Player.ToString()))
        {
            bingusInArea = false;
            if (enemySoldier.catName == "Bingus")
            {
                spriteRenderer.color = new Color32(10, 10, 10, 250);
            }
            else spriteRenderer.color = new Color32(255, 255, 255, 255);
            trail.SetActive(true);
            enemySoldier.enemyMovementSpeed = enemies.enemySpeed;
        }
    }
}

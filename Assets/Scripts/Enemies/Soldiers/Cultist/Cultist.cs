using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Assets.Scripts.EnumTypes;

public class Cultist : MonoBehaviour
{
    private GameObject[] coins;
    [HideInInspector] public EnemySoldier enemySoldier;
    [HideInInspector] public int count;
    SpriteRenderer spriteRenderer;
    float dmgUpgrade;
    float speedUpgrade;
    ParticleSystem particleSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        enemySoldier = GetComponent<EnemySoldier>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dmgUpgrade = enemySoldier.enemyDMG + 1f;
        speedUpgrade = enemySoldier.enemyMovementSpeed + 0.5f;
        particleSpawn = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        coins = GameObject.FindGameObjectsWithTag(ObjectTags.Coin.ToString());
        count = coins.Length;
        CultistStats();
        //Debug.Log(count);
    }

    void CultistStats()
    {
        if (count > 1 && count < 4)
        {
            enemySoldier.enemyMovementSpeed = speedUpgrade;
            spriteRenderer.color = new Color(0.5f, 0.8f, 1f, 1f);
            particleSpawn.Stop();
        }
        else if (count >= 4)
        {
            enemySoldier.enemyMovementSpeed = speedUpgrade + 0.5f;
            spriteRenderer.color = new Color(0.2f, 0.2f, 1f, 1f);
            enemySoldier.enemyDMG = dmgUpgrade;
            particleSpawn.Play();
            //spriteRenderer.color = new Color(1f, 0f, 0f, 1f);
        }
        else
        {
            enemySoldier.enemyMovementSpeed = enemySoldier.enemyMovementSpeed;
            enemySoldier.enemyDMG = enemySoldier.enemyDMG;
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            particleSpawn.Stop();
        }
    }
}

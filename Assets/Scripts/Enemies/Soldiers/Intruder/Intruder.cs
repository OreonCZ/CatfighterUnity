using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Assets.Scripts.EnumTypes;

public class Intruder : MonoBehaviour
{
    private GameObject[] coins;
    EnemySoldier enemySoldier;
    [HideInInspector] public int count;
    SpriteRenderer spriteRenderer;
     [HideInInspector] public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        enemySoldier = GetComponent<EnemySoldier>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        coins = GameObject.FindGameObjectsWithTag(ObjectTags.Coin.ToString());
        count = coins.Length;
        IntruderStats();
        Debug.Log(count);
    }

    void IntruderStats()
    {
        if (count > 1 && count <= 4)
        {
            //agent.speed = (enemySoldier.enemyMovementSpeed + 1f);
            spriteRenderer.color = new Color(1f, 0.475f, 0.475f, 1f);
        }
        else if (count > 4)
        {
            //agent.speed = (enemySoldier.enemyMovementSpeed + 2f);
            enemySoldier.enemyDMG = (enemySoldier.enemyDMG + 1f);
            spriteRenderer.color = new Color(1f, 0f, 0f, 1f);
        }
        else
        {
            //agent.speed = enemySoldier.enemyMovementSpeed;
            enemySoldier.enemyDMG = enemySoldier.enemyDMG;
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}

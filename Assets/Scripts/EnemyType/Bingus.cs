using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bingus : MonoBehaviour
{
    public Enemy enemy;
    public EnemyMovement enemyMovement;
    public SpriteRenderer spriteRenderer;
    TakingDmgPlayer takingDMGPlayer;
    // Start is called before the first frame update
    void Start()
    {
        takingDMGPlayer = gameObject.GetComponent<TakingDmgPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.currentEnemyHP <= 4)
        {
            if (!takingDMGPlayer.enemyTakeDmg)
            {
                enemy.enemyMovementSpeed = 3f;
                spriteRenderer.color = new Color(1f, 1f, 1f, 0.01f);
            }
            else
            {
                spriteRenderer.color = new Color(0.3f, 0.3f, 0.3f, 1f);
            }
            enemy.enemyDMG = 2;
        }
}
}

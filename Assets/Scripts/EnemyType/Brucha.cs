using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brucha : MonoBehaviour
{
    public Enemy enemy;
    public GameObject grid;
    public GameObject bruchaBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BruchaUpdate();
    }

    void BruchaUpdate()
    {
        if(enemy.currentEnemyHP <= 15 && enemy.currentEnemyHP > 10)
        {
            grid.SetActive(false);
            enemy.enemyMovementSpeed = 4f;
            enemy.enemyRangeDMG = 0;
        }
    }
}

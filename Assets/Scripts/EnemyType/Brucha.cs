using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brucha : MonoBehaviour
{
    public Enemy enemy;
    public Enemies enemies;
    public GameObject grid;
    public GameObject bruchaBullet;
    bool transform = false;

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
            StartCoroutine(Transformation());
            
        }
    }

    IEnumerator Transformation()
    {
        if (!transform)
        {
            enemy.enemyMovementSpeed = 0f;
            yield return new WaitForSeconds(3);
            enemy.enemyMovementSpeed = 4f;
            enemy.enemyRangeDMG = 0;
            grid.SetActive(false);
            transform = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruchaSecondPhase : MonoBehaviour
{
    GameObject swordRadius;
    int randomNumber = 0;
    public Brucha brucha;
    public GameObject enemyBrucha;
    public GameObject player;
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        swordRadius = GameObject.FindWithTag("Sword");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy" && brucha.transformBrucha && !enemy.enemyDed)
        {
            randomNumber = Random.Range(0, 8);
            if(randomNumber == 0)
            {
                enemyBrucha.transform.position = new Vector2(player.gameObject.transform.position.x, player.gameObject.transform.position.y + 2);
            }
            else if (randomNumber == 1)
            {
                enemyBrucha.transform.position = new Vector2(player.gameObject.transform.position.x, player.gameObject.transform.position.y - 2);
            }
            else if (randomNumber == 2)
            {
                enemyBrucha.transform.position = new Vector2(player.gameObject.transform.position.x - 2, player.gameObject.transform.position.y);
            }
            else if (randomNumber == 3)
            {
                enemyBrucha.transform.position = new Vector2(player.gameObject.transform.position.x + 2, player.gameObject.transform.position.y);
            }
            else if (randomNumber == 4)
            {
                enemyBrucha.transform.position = new Vector2(player.gameObject.transform.position.x + 2, player.gameObject.transform.position.y + 2);
            }
            else if (randomNumber == 5)
            {
                enemyBrucha.transform.position = new Vector2(player.gameObject.transform.position.x - 2, player.gameObject.transform.position.y - 2);
            }
            else if (randomNumber == 6)
            {
                enemyBrucha.transform.position = new Vector2(player.gameObject.transform.position.x - 2, player.gameObject.transform.position.y + 2);
            }
            else if (randomNumber == 7)
            {
                enemyBrucha.transform.position = new Vector2(player.gameObject.transform.position.x + 2, player.gameObject.transform.position.y - 2);
            }
        }
    }
}

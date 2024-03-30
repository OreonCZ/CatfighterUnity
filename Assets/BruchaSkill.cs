using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruchaSkill : MonoBehaviour
{
    public GameObject bruchaSkill;
    public Movement playerMovement;
    public EnemyProjectileDMG enemyProjectileDMG;
    public Enemy enemy;
    public GameObject brucha;
    int randomNumber = 0;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            randomNumber = Random.Range(0, 5);
            StartCoroutine(BruchaSkill());
            if (enemy.currentEnemyHP <= 15 && enemy.currentEnemyHP > 10)
            {
                if(randomNumber == 1)
                {
                    brucha.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 2);
                }
                else if (randomNumber == 2)
                {
                    brucha.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 2);
                }
                else if (randomNumber == 3)
                {
                    brucha.transform.position = new Vector2(this.gameObject.transform.position.x - 2, this.gameObject.transform.position.y);
                }
                else if (randomNumber == 4)
                {
                    brucha.transform.position = new Vector2(this.gameObject.transform.position.x + 2, this.gameObject.transform.position.y);
                }

            }

        }
        IEnumerator BruchaSkill()
        {
            bruchaSkill.SetActive(true);
            yield return new WaitForSeconds(1.1f);
            if (!playerMovement.isRolling)
            {
                enemyProjectileDMG.OnHitDamage(enemy.enemyRangeDMG);
            }
            yield return new WaitForSeconds(0.3f);
            bruchaSkill.SetActive(false);
        }
    }
}

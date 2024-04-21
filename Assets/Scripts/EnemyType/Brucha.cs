using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brucha : MonoBehaviour
{
    public Enemy enemy;
    public Enemies enemies;
    public GameObject grid;
    public GameObject bruchaBullet;
    public bool transformBrucha = false;
    public bool canShoot = true;
    public Animator animator;
    public Text bruchaName;
    string bruchaBossName;
    public AudioClip phaseOne;
    public AudioClip phaseTwo;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = phaseOne;
    }

    // Update is called once per frame
    void Update()
    {
        BruchaUpdate();
    }

    void BruchaUpdate()
    {
        if(enemy.currentEnemyHP <= 10)
        {
            StartCoroutine(Transformation());
            bruchaBossName = "Brucha, the possessed Catfighter";
            bruchaName.text = bruchaBossName;
            bruchaBullet.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
        }
        else
        {
            bruchaBullet.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    IEnumerator Transformation()
    {
        if (!transformBrucha)
        {
            canShoot = false;
            StartCoroutine(BruchaMusic());
            animator.SetBool("isTransforming", true);
            enemy.enemyMovementSpeed = 0f;
            enemy.enemyRangeSpeed = 30f;
            yield return new WaitForSeconds(1.1f);
            enemy.enemyMovementSpeed = 3.5f;
            enemy.enemyRangeDMG = 2;
            grid.SetActive(false);
            canShoot = true;
            transformBrucha = true;
            animator.SetBool("isTransforming", false);
        }
    }

    IEnumerator BruchaMusic()
    {
        audioSource.Pause();
        audioSource.clip = phaseTwo;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.Pause();
        audioSource.clip = phaseOne;
        audioSource.Play();
    }
}

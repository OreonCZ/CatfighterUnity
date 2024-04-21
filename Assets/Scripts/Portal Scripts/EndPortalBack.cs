using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPortalBack : MonoBehaviour
{
    public bool teleport = false;
    public GameObject endTransition;
    public Transform playerPos;
    public Enemy enemy;
    public Transform portalEnd;
    bool portal = false;
    public PauseGame pause;
    public GameObject endingUI;
    public GameObject gameUI;
    public GameObject camera;
    public CursorConfig cursor;
    public AudioSource audioSource;
    public AudioClip mainTheme;
    public GameObject enemyBrucha;

    void Update()
    {
        if(enemy.currentEnemyHP <= 0)
        {
            StartCoroutine(PortalSpawn());
        }

        if (teleport)
        {
            endingUI.SetActive(true);
            gameUI.SetActive(false);
            endTransition.SetActive(false);
            cursor.endBool = true;
        }
    }

    void DisableEndTransition()
    {
        endTransition.SetActive(true);
    }

    IEnumerator PortalSpawn()
    {
        if (!portal)
        {
            portalEnd.position = new Vector2(playerPos.position.x, playerPos.position.y + 2);
        }
        yield return new WaitForSeconds(0f);
        portal = true;
    }

    IEnumerator LevelLoading()
    {
        audioSource.Pause();
        Destroy(enemyBrucha);
        pause.canPause = false;
        yield return new WaitForSeconds(2f);
        EndingMusic();
        teleport = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        DisableEndTransition();
        Debug.Log("sus");
        StartCoroutine(LevelLoading());
    }

    void EndingMusic()
    {
        //Good ending
        if (PlayerPrefs.GetInt("KevinKilled") == 0 && PlayerPrefs.GetInt("YukiKilled") == 0 && PlayerPrefs.GetInt("MiscarKilled") == 0
            && PlayerPrefs.GetInt("BingusKilled") == 0 && PlayerPrefs.GetInt("OscarKilled") == 0 && PlayerPrefs.GetInt("BruchaKilled") == 0)
        {
            Debug.Log("GoodEnding");
            audioSource.clip = mainTheme;
            audioSource.Play();
        }
        else if (PlayerPrefs.GetInt("KevinKilled") == 1 && PlayerPrefs.GetInt("YukiKilled") == 1 && PlayerPrefs.GetInt("MiscarKilled") == 1
            && PlayerPrefs.GetInt("BingusKilled") == 1 && PlayerPrefs.GetInt("OscarKilled") == 1 && PlayerPrefs.GetInt("BruchaKilled") == 1)
        {
            Debug.Log("BadEnding");
            AudioListener.pause = mainTheme;
        }
        else
        {
            Debug.Log("Neutral");
            audioSource.clip = mainTheme;
            audioSource.Play();
        }
    }
}

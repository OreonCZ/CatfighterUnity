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
            AudioListener.pause = true;
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
        pause.canPause = false;
        yield return new WaitForSeconds(2f);
        teleport = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        DisableEndTransition();
        Debug.Log("sus");
        StartCoroutine(LevelLoading());
    }
}
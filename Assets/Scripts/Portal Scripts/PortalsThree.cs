using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalsThree : MonoBehaviour
{
    public bool teleport = false;
    public GameObject endTransition;
    public PauseGame pauseGame;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (teleport)
        {
            
            SceneManager.LoadScene(sceneBuildIndex: 4);
        }
    }
    void DisableEndTransition()
    {
        endTransition.SetActive(true);
    }

    IEnumerator LevelLoading()
    {
        pauseGame.canPause = false;
        yield return new WaitForSeconds(1.5f);
        teleport = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        DisableEndTransition();
        Debug.Log("sus");
        StartCoroutine(LevelLoading());
    }
}

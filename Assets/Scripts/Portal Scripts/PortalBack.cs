using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBack : MonoBehaviour
{
    public bool teleport = false;
    public GameObject endTransition;
    public PauseGame pause;

    void Update()
    {
        if (teleport)
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);

        }
    }

    void DisableEndTransition()
    {
        endTransition.SetActive(true);
    }

    IEnumerator LevelLoading()
    {
        pause.canPause = false;
        yield return new WaitForSeconds(1f);
        teleport = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        DisableEndTransition();
        Debug.Log("sus");
        StartCoroutine(LevelLoading());
    }
}

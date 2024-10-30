using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex: 0);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}

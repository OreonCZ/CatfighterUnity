using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DedScreen : MonoBehaviour
{
    public void Respawn()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}

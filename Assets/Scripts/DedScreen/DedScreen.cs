using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DedScreen : MonoBehaviour
{
    public int back;
    Scene scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void Respawn()
    {
        SceneManager.LoadScene(sceneBuildIndex: scene.buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: back);
    }
}

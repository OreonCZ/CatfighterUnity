using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBack : MonoBehaviour
{
    public bool teleport = false;

    void Update()
    {
        if (teleport)
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("sus");
        teleport = true;
    }
}

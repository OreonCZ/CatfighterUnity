using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalsOne : MonoBehaviour
{
    public bool teleport = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (teleport)
        {
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("sus");
        teleport = true;
    }
}

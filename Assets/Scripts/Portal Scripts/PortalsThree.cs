using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalsThree : MonoBehaviour
{
    public bool teleport = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (teleport)
        {
            SceneManager.LoadScene(sceneBuildIndex: 4);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("sus");
        teleport = true;

    }
}

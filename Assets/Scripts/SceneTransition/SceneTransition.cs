using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject startTransition;
    public PauseGame pause;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.pause = false;
        startTransition.SetActive(true);
        StartCoroutine(DisableStartTransition());
    }

    IEnumerator DisableStartTransition()
    {
        yield return new WaitForSeconds(1f);
        startTransition.SetActive(false);
        PauseGame.canPause = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

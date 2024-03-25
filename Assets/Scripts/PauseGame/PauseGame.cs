using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [HideInInspector] public bool pauseBool;
    [HideInInspector] public bool canPause = false;
    Fight fight;
    Movement playerMovement;
    public GameObject pauseMenu;
    public GameObject gameMenu;
    public SceneTransition sceneTransition;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        fight = player.GetComponent<Fight>();
        playerMovement = player.GetComponent<Movement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            pauseBool = !pauseBool;
            Pause();
        }
    }

    void Pause()
    {
        if (pauseBool)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            fight.canAttack = false;
            playerMovement.canWalk = false;
            pauseMenu.SetActive(true);
            gameMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            fight.canAttack = true;
            playerMovement.canWalk = true;
            pauseMenu.SetActive(false);
            gameMenu.SetActive(true);
        }
    }
}


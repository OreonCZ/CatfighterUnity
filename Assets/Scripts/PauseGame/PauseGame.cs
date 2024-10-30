using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [HideInInspector] public bool pauseBool;
    [HideInInspector] public static bool canPause = false;
    Fight fight;
    Movement playerMovement;
    public GameObject pauseMenu;
    public GameObject pauseMenuFirst;
    public GameObject pauseMenuSecond;
    public GameObject gameMenu;
    public GameObject bruchaSkill;
    public SceneTransition sceneTransition;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        fight = player.GetComponent<Fight>();
        playerMovement = player.GetComponent<Movement>();
        canPause = true;
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
            fight.canAttack = false;
            playerMovement.canWalk = false;
            pauseMenu.SetActive(true);
            pauseMenuFirst.SetActive(true);
            pauseMenuSecond.SetActive(false);
            gameMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            fight.canAttack = true;
            playerMovement.canWalk = true;
            pauseMenu.SetActive(false);
            gameMenu.SetActive(true);
            pauseMenuSecond.SetActive(false);
            pauseMenuFirst.SetActive(false);
        }
    }
}


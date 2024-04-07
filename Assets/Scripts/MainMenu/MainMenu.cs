using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider audioSlider;
    public AudioMixer audioMixer;

    void Start()
    {
        AudioListener.pause = false;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void NewGame()
    {
        float volume = audioSlider.value;
        audioMixer.SetFloat("master", Mathf.Log10(volume) * 20);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("audioVolume", volume);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Player has left the game");
    }
}

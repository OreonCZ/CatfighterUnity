using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject mainpage;
    public GameObject settings;

    public void Config()
    {
        mainpage.SetActive(false);
        settings.SetActive(true);
    }

    public void Back()
    {
        mainpage.SetActive(true);
        settings.SetActive(false);
    }

    public void KevinMacleod()
    {
        Application.OpenURL("https://www.youtube.com/@incompetech_kmac");
    }
    public void Playlist()
    {
        Application.OpenURL("https://suno.com/playlist/923bd507-c59d-46e3-9a3b-873ee3ff0d2a");
    }

    public void Cainos()
    {
        Application.OpenURL("https://itch.io/profile/cainos");
    }
}

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
    public void PunchDeck()
    {
        Application.OpenURL("https://www.youtube.com/punchdeck");
    }

    public void MakaiSymphony()
    {
        Application.OpenURL("https://www.youtube.com/@Makai-symphony");
    }
    public void Cainos()
    {
        Application.OpenURL("https://itch.io/profile/cainos");
    }
}

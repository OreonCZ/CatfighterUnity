using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsInGame : MonoBehaviour
{
    public GameObject originalPause;
    public GameObject settingsPause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameSettings()
    {
        originalPause.SetActive(false);
        settingsPause.SetActive(true);
    }
    public void Settings() {
        originalPause.SetActive(true);
        settingsPause.SetActive(false);
    }
}

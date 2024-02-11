using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalUnlockScript : MonoBehaviour
{
    public GameObject portalOne;
    public GameObject portalTwo;
    public GameObject portalThree;
    public GameObject portalFour;
    public GameObject portalFive;
    public GameObject portalSix;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("KevinKilled") == 1)
        {
            portalOne.SetActive(false);
        }
        if(PlayerPrefs.GetInt("level1") == 1)
        {
            portalTwo.SetActive(true);
            if(PlayerPrefs.GetInt("YukiKilled") == 1)
            {
                portalTwo.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("level2") == 1)
        {
            portalThree.SetActive(true);
            if (PlayerPrefs.GetInt("MiscarKilled") == 1)
            {
                portalThree.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("level3") == 1)
        {
            portalFour.SetActive(true);
            if (PlayerPrefs.GetInt("BingusKilled") == 1)
            {
                portalFour.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("level4") == 1)
        {
            portalFive.SetActive(true);
            if (PlayerPrefs.GetInt("OscarKilled") == 1)
            {
                portalFive.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("level5") == 1)
        {
            portalSix.SetActive(true);
            if (PlayerPrefs.GetInt("BruchaKilled") == 1)
            {
                portalSix.SetActive(false);
            }
        }
    }
}

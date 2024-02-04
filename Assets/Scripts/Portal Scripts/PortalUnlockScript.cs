using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalUnlockScript : MonoBehaviour
{
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
        if(PlayerPrefs.GetInt("level") == 1)
        {
            portalTwo.SetActive(true);
        }
        if (PlayerPrefs.GetInt("level") == 2)
        {
            portalTwo.SetActive(true);
            portalThree.SetActive(true);
        }
        if (PlayerPrefs.GetInt("level") == 3)
        {
            portalTwo.SetActive(true);
            portalThree.SetActive(true);
            portalFour.SetActive(true);
        }
        if (PlayerPrefs.GetInt("level") == 4)
        {
            portalTwo.SetActive(true);
            portalThree.SetActive(true);
            portalFour.SetActive(true);
            portalFive.SetActive(true);
        }
        if (PlayerPrefs.GetInt("level") == 5)
        {
            portalTwo.SetActive(true);
            portalThree.SetActive(true);
            portalFour.SetActive(true);
            portalFive.SetActive(true);
            portalSix.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingImage : MonoBehaviour
{
    public Sprite goodEnding;
    public Sprite badEnding;
    public Sprite neutralEnding;
    public GameObject endingUI;
    
    public EndPortalBack endPortalBack;

    // Start is called before the first frame update
    void Start()
    {
        Ending();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ending()
    {
        //Good ending
        if(PlayerPrefs.GetInt("KevinKilled") == 0 && PlayerPrefs.GetInt("YukiKilled") == 0 && PlayerPrefs.GetInt("MiscarKilled") == 0
            && PlayerPrefs.GetInt("BingusKilled") == 0 && PlayerPrefs.GetInt("OscarKilled") == 0 && PlayerPrefs.GetInt("BruchaKilled") == 0 && endPortalBack.teleport)
        {
            Debug.Log("GoodEnding");
            endingUI.GetComponent<Image>().sprite = goodEnding;
        }
        else if(PlayerPrefs.GetInt("KevinKilled") == 1 && PlayerPrefs.GetInt("YukiKilled") == 1 && PlayerPrefs.GetInt("MiscarKilled") == 1
            && PlayerPrefs.GetInt("BingusKilled") == 1 && PlayerPrefs.GetInt("OscarKilled") == 1 && PlayerPrefs.GetInt("BruchaKilled") == 1 && endPortalBack.teleport)
        {
            Debug.Log("BadEnding");
            endingUI.GetComponent<Image>().sprite = badEnding;
        }
        else
        {
            Debug.Log("Neutral");
            endingUI.GetComponent<Image>().sprite = neutralEnding;
        }
    }
}

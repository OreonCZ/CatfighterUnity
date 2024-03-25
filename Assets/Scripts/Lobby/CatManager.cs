using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatManager : MonoBehaviour
{
    public GameObject kevin;
    public GameObject yuki;
    public GameObject miscar;
    public GameObject oscar;
    public GameObject cave;
    public GameObject statue;
    public Sprite brokenStatue;
    public Sprite bingus;
    //public GameObject brucha;

    // Start is called before the first frame update
    void Start()
    {
        cave.GetComponent<SpriteRenderer>();
        statue.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("level1") == 1 && PlayerPrefs.GetInt("KevinKilled") == 0)
        {
            kevin.SetActive(true);
        }
        if(PlayerPrefs.GetInt("level2") == 1 && PlayerPrefs.GetInt("YukiKilled") == 0)
        {
            yuki.SetActive(true);
        }
        if (PlayerPrefs.GetInt("level3") == 1 && PlayerPrefs.GetInt("MiscarKilled") == 0)
        {
            miscar.SetActive(true);
        }
        if (PlayerPrefs.GetInt("level4") == 1 && PlayerPrefs.GetInt("BingusKilled") == 0)
        {
            cave.GetComponent<SpriteRenderer>().sprite = bingus;
        }
        if (PlayerPrefs.GetInt("level5") == 1)
        {
            statue.GetComponent<SpriteRenderer>().sprite = brokenStatue;
            if(PlayerPrefs.GetInt("OscarKilled") == 0)
            {
                oscar.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("BruchaKilled") == 0)
        {
            //brucha.SetActive(true);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEnd : MonoBehaviour
{
    public GameObject map;
    public GameObject cave;
    public GameObject oscarStatue;
    public GameObject tDummy;
    public AudioSource audioSource;
    public AudioClip badEnd;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("KevinKilled") == 1 && PlayerPrefs.GetInt("YukiKilled") == 1 && PlayerPrefs.GetInt("MiscarKilled") == 1
            && PlayerPrefs.GetInt("BingusKilled") == 1 && PlayerPrefs.GetInt("OscarKilled") == 1 && PlayerPrefs.GetInt("BruchaKilled") == 1)
        {
            map.SetActive(false);
            cave.SetActive(false);
            oscarStatue.SetActive(false);
            tDummy.SetActive(false);
            audioSource.clip = badEnd;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

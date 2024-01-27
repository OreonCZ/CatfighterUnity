using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkUI : MonoBehaviour
{
    public Milk milk;
    public GameObject player;
    public Text numberOfMilk;
    string currentMilkString;

    // Start is called before the first frame update
    void Start()
    {
        milk = player.GetComponent<Milk>();
    }

    // Update is called once per frame
    void Update()
    {
        currentMilkString = milk.numberOfMilk.ToString();
        numberOfMilk.text = currentMilkString;
    }
}

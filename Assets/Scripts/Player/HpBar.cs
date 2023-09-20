using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider slider;
    public int maxHp = 8;
    public int currentHp;

    void Start()
    {
        currentHp = maxHp;
        slider.maxValue = maxHp;
    }

    void Update()
    {
        slider.value = currentHp;
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            TakeDmg(1); 
        }
    }
    
    public void TakeDmg(int damage)
    {
        currentHp -= damage;
    }

}

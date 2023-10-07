using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHead : MonoBehaviour
{
    public Image head;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    Slider slider;
    [SerializeField] GameObject slider2;

    void Start()
    {
        slider = slider2.GetComponent<Slider>();
    }

    void Update()
    {
        if(slider.value > 5)
        {
            head.sprite = sprite1;
        }

       else if(slider.value < 5 && slider.value > 2)
        {
            head.sprite = sprite2;
        }
        else if (slider.value < 2)
        {
            head.sprite = sprite3;
        }
    }
}

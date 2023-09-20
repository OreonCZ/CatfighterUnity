using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHead : MonoBehaviour
{

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    Slider slider;

    void Update()
    {
        if(slider.value >= 5)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
        }

       else if(slider.value < 5)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        else if (slider.value < 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;
        }
    }
}

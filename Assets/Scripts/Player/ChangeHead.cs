using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHead : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    Image image;
    Slider slider;

    public void Change()
    {
        if(slider.value >= 5)
        {
            image.GetComponent<UnityEngine.UI.Image>().sprite = sprite1;
        }

       else if(slider.value < 5)
        {
            image.GetComponent<UnityEngine.UI.Image>().sprite = sprite2;
        }
        else if (slider.value < 3)
        {
            image.GetComponent<UnityEngine.UI.Image>().sprite = sprite3;
        }
    }
}

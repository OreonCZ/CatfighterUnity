using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowHpUI : MonoBehaviour
{
    public Slider slider;
    public Image uiImage;
    public Sprite bloodyImage;
    // Start is called before the first frame update
    void Start()
    {
        uiImage = this.GetComponent<Image>();
        uiImage.sprite = bloodyImage;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value == 1)
        {
            uiImage.color = new Color(1f, 1f, 1f, 0.8f);
        }
        else if (slider.value == 2)
        {
            uiImage.color = new Color(1f, 1f, 1f, 0.4f);
        }
        else
        {
            uiImage.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}

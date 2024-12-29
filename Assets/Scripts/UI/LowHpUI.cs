using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowHpUI : MonoBehaviour
{
    public Slider slider;
    public Image uiImage;
    public Sprite bloodyImage;
    GameObject player;
    HpBar playerHp;
    // Start is called before the first frame update
    void Start()
    {
        uiImage = this.GetComponent<Image>();
        uiImage.sprite = bloodyImage;
        player = GameObject.Find("Player");
        playerHp = player.GetComponent<HpBar>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(playerHp.currentHp <= playerHp.maxHp / 4)
        {
            uiImage.color = new Color(1f, 1f, 1f, 0.8f);
        }
        else if (playerHp.currentHp <= playerHp.maxHp / 2)
        {
            uiImage.color = new Color(1f, 1f, 1f, 0.4f);
        }
        else
        {
            uiImage.color = new Color(1f, 1f, 1f, 0f);
        }*/
        BloodyScreen(playerHp.currentHp);
    }

    private void BloodyScreen(float currentHp)
    {
        float normalizedHp = Mathf.Clamp01(currentHp / playerHp.maxHp);

        float alpha = Mathf.Lerp(0.8f, 0f, normalizedHp);
        uiImage.color = new Color(1f, 1f, 1f, alpha);
    }
}

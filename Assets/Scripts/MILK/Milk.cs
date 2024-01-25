using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Milk : MonoBehaviour
{
    public HpBar hpBar;
    public Animator animator;
    public int healMilk = 1;
    public int milkNumber = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 2; i++)
        {
            Drink();
        }
    }

    void Drink() {
        if (Input.GetKey(KeyCode.E) && hpBar.currentHp < hpBar.maxHp)
        {
            hpBar.currentHp += healMilk;
            animator.SetTrigger("Drink");
            Debug.Log(hpBar.currentHp);
        }
    }
}

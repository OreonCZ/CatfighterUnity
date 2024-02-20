using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorConfig : MonoBehaviour
{
    public HpBar hpbar;
    void Start()
    {
        
    }
    void Update()
    {
        if (hpbar.currentHp > 0)
        {
            Cursor.visible = false;
            return;
        }
        else {
        Cursor.visible = true;
            return;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorConfig : MonoBehaviour
{
    public HpBar hpbar;
    void Start()
    {
        if(hpbar.currentHp > 0) {
        Cursor.visible = false;
        }
    }

}

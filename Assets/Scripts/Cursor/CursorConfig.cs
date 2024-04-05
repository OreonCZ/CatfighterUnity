using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorConfig : MonoBehaviour
{
    public HpBar hpbar;
    public PauseGame pause;
    public bool endBool = false;

    void Start()
    {
        
    }
    void Update()
    {
        if (hpbar.currentHp > 0)
        {
            if (pause.pauseBool)
            {
                Cursor.visible = true;
                return;
            }
            else if (endBool)
            {
                Cursor.visible = true;
                return;
            }
            else
            {
                Cursor.visible = false;
            }
        }

        else {
        Cursor.visible = true;
            return;
        }
    }

}

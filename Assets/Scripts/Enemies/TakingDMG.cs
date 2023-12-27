using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakingDMG : MonoBehaviour
{
    public bool isHit;
    public Fight fight;
    bool hit;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("gkopsjkgops");
        }

    }
}


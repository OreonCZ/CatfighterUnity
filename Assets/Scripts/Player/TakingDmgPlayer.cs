using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakingDmgPlayer : MonoBehaviour
{
    public HpBar hpbar;
    public Enemies enemy;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered collision with " + collision.gameObject.name);
    }
}

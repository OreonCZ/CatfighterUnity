using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip swordSwing;
    public Fight fight;

    void Update()
    {
            if (Input.GetMouseButtonDown(0) && fight.canAttack)
            {
                audio.clip = swordSwing;
                audio.Play();
            }

    }
    
}

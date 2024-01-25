using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public new AudioSource audio;
    public AudioClip swordSwing;
    public Fight fight;
    public Movement playerMovement;

    void Update()
    {
            if (fight.isFighting && fight.fightSound && playerMovement.isWalking)
            {
                audio.clip = swordSwing;
                audio.Play();
            }

    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public new AudioSource audio;
    public AudioClip swordSwing;
    public AudioClip drinkMilk;
    public Fight fight;
    public Milk milk;
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

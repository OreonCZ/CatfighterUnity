using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

public class SoundEffects : MonoBehaviour
{
    public new AudioSource audio;
    public AudioClip swordSwing;
    public AudioClip drinkMilk;
    Fight fight;
    Milk milk;
    Movement playerMovement;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(ObjectTags.Player.ToString());
        fight = player.GetComponent<Fight>();
        milk = player.GetComponent<Milk>();
        playerMovement = player.GetComponent<Movement>();
    }

    void Update()
    {
        Slash();
    }

    void Slash()
    {
        if (fight.isFighting && fight.fightSound)
        {
            audio.clip = swordSwing;
            audio.Play();
        }
    }
    
}

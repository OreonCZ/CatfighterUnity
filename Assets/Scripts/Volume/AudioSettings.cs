using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Assets.Scripts.EnumTypes;

public class AudioSettings : MonoBehaviour
{
    [HideInInspector] public GameObject music;
    public Slider audioSlider;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindGameObjectWithTag(ObjectTags.Music.ToString());
        VolumeManager();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayerPrefs.DeleteKey("audioVolume");
        }
    }


    public void SetAudioVolume()
    {
        float volume = audioSlider.value;
        audioMixer.SetFloat("master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("audioVolume", volume);
    }

    public void LoadVolume()
    {
        audioSlider.value = PlayerPrefs.GetFloat("audioVolume");
        SetAudioVolume();
    }

    void VolumeManager()
    {
        if (PlayerPrefs.HasKey("audioVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetAudioVolume();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;


public class AudioManager : MonoBehaviour
{
    public SoundsSystemData[] sounds;

    public static AudioManager _instance;

    public AudioMixer masterMixer;
    public Slider musicSlider;

    [Range(-80f, 10f)]
    public float masterVol;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        foreach (SoundsSystemData s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
        }
    }
    void Start()
    {
        

        musicSlider.minValue = -80f;
        musicSlider.maxValue = 10f;

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 10f);

    }
    public void MusicVolume()
    {
        DataManager._instance.MusicData(musicSlider.value);
        masterMixer.SetFloat("masterVol", PlayerPrefs.GetFloat("mixerMaster"));
    }


    public void Play(string name)
    {
        SoundsSystemData s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}

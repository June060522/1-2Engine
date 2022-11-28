using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectAudio : MonoBehaviour
{
    public Slider EffVolume;
    public AudioSource _audio;

    private float effVol = 1f;

    public static EffectAudio instance;
    void Awake()
    {
        EffectAudio.instance = this;
    }
    void Start()
    {
        effVol = PlayerPrefs.GetFloat("effvol", 1f);
        EffVolume.value = effVol;
        _audio.volume = EffVolume.value;
        
    }

    void Update()
    {
        _audio.volume = EffVolume.value;

        effVol = EffVolume.value;
        PlayerPrefs.SetFloat("effvol", effVol);
    }

    public void ListenEff(AudioClip a)
    {
        _audio.clip = a;
        _audio.Play();
    }
}

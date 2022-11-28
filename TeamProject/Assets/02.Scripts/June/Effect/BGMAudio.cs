using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMAudio : MonoBehaviour
{
    public Slider backVolume;
    public AudioSource _audio;

    private float backVol = 1f;

    void Start()
    {
        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        backVolume.value = backVol;
        _audio.volume = backVolume.value;
        
    }

    void Update()
    {
        _audio.volume = backVolume.value;

        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backvol", backVol);
    }
}

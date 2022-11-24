using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource BGMSource;
   
    //public AudioSource SoundEffect;
    public void SetBGMVolume(float volume)
    {
        BGMSource.volume = volume;
    }

    /*public void SetMusicVolume(float volume)
    {
        SoundEffect.volume = volume;
    }*/
}

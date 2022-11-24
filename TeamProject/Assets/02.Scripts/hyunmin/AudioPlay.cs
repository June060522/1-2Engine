using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource BGMSource;
    
    public void SetMusicVolume(float volume)
    {
        BGMSource.volume = volume;
    }
}

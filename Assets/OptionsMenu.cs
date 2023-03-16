using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    
    public AudioMixer soundEffectsMixer;
    public AudioMixer musicMixer;


    

    public void SetSoundEffectVolume(float volume)
    {
        soundEffectsMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }    

    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

}

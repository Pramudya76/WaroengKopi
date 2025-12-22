using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager {get; private set;}
    public AudioMixer audioMixer;
    public AudioSource MusicVolume;
    public AudioSource SFXVolume;
    void Awake()
    {
        if(audioManager != null && audioManager != this)
        {
            Destroy(gameObject);
            return;
        }
        audioManager = this;
        DontDestroyOnLoad(gameObject);
        LoadVolume();
    }

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("VolMaster", ToMixerVolume(value));
        PlayerPrefs.SetFloat("VolMaster", value);
    }

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("VolMusic", ToMixerVolume(value));
        PlayerPrefs.SetFloat("VolMusic", value);
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("VolSFX", ToMixerVolume(value));
        PlayerPrefs.SetFloat("VolSFX", value); 
    }

    public void PlayBGM(AudioClip clip)
    {
        if(MusicVolume.clip == clip) return;
        MusicVolume.clip = clip;
        MusicVolume.loop = true;
        MusicVolume.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXVolume.PlayOneShot(clip);
    }

    float ToMixerVolume(float value)
    {
        value = Mathf.Clamp(value,0.0001f, 1f);
        return Mathf.Log10(value) * 20;
    }

    public void LoadVolume()
    {
        float Master = PlayerPrefs.GetFloat("VolMaster", 1f);
        float Music = PlayerPrefs.GetFloat("VolMusic", 1f);
        float SFX = PlayerPrefs.GetFloat("VolSFX", 1f);

        audioMixer.SetFloat("VolMaster", ToMixerVolume(Master));
        audioMixer.SetFloat("VolMusic", ToMixerVolume(Music));
        audioMixer.SetFloat("VolSFX", ToMixerVolume(SFX));

    }

}

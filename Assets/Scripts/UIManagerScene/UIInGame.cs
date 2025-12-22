using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    public static UIInGame uIInGame;
    public GameObject PausedPanel;
    public GameObject SettingPanel;
    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider SFXSlider;
    public AudioClip ButtonPress;
    // Start is called before the first frame update
    void Start()
    {
        if(uIInGame == null)
        {
            uIInGame = this;
        }
        PausedPanel.SetActive(false);
        SettingPanel.SetActive(false);
        
        SetSlider();
    }

    public void PausedGame()
    {
        AudioManager.audioManager.PlaySFX(ButtonPress);
        PausedPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        AudioManager.audioManager.PlaySFX(ButtonPress);
        PausedPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void SettingPanelOpen()
    {
        AudioManager.audioManager.PlaySFX(ButtonPress);
        PausedPanel.SetActive(false);
        SettingPanel.SetActive(true);
    }

    public void SettingPanelClose()
    {
        AudioManager.audioManager.PlaySFX(ButtonPress);
        PausedPanel.SetActive(true);
        SettingPanel.SetActive(false);
        PlayerPrefs.Save();
    }

    public void Exit()
    {
        AudioManager.audioManager.PlaySFX(ButtonPress);
        SceneManager.LoadScene("ChoseLevel");
        Time.timeScale = 1;
    }

    public void SetSlider()
    {
        float Master = PlayerPrefs.GetFloat("VolMaster", 1f);
        float Music = PlayerPrefs.GetFloat("VolMusic", 1f);
        float SFX = PlayerPrefs.GetFloat("VolSFX", 1f);

        MasterSlider.value = Master;
        MusicSlider.value = Music;
        SFXSlider.value = SFX;

        MasterSlider.onValueChanged.AddListener(AudioManager.audioManager.SetMasterVolume);
        MusicSlider.onValueChanged.AddListener(AudioManager.audioManager.SetMusicVolume);
        SFXSlider.onValueChanged.AddListener(AudioManager.audioManager.SetSFXVolume);
    }
}

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
    // Start is called before the first frame update
    void Start()
    {
        if(uIInGame == null)
        {
            uIInGame = this;
        }
        PausedPanel.SetActive(false);
        SettingPanel.SetActive(false);
        
        MasterSlider.onValueChanged.AddListener(AudioManager.audioManager.SetMasterVolume);
        MusicSlider.onValueChanged.AddListener(AudioManager.audioManager.SetMusicVolume);
        SFXSlider.onValueChanged.AddListener(AudioManager.audioManager.SetSFXVolume);
    }

    public void PausedGame()
    {
        PausedPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PausedPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void SettingPanelOpen()
    {
        PausedPanel.SetActive(false);
        SettingPanel.SetActive(true);
    }

    public void SettingPanelClose()
    {
        PausedPanel.SetActive(true);
        SettingPanel.SetActive(false);
        PlayerPrefs.Save();
    }

    public void Exit()
    {
        SceneManager.LoadScene("ChoseLevel");
    }

    public void SetSlider()
    {
        float Master = PlayerPrefs.GetFloat("VolMaster", 1f);
        float Music = PlayerPrefs.GetFloat("VolMusic", 1f);
        float SFX = PlayerPrefs.GetFloat("VolSFX", 1f);

        MasterSlider.value = Master;
        MusicSlider.value = Music;
        SFXSlider.value = SFX;
    }
}

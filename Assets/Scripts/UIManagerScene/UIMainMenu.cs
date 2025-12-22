using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public static UIMainMenu uIMainMenu {get; private set;}
    public GameObject settingPanel;
    public GameObject PanelHaveProgress;
    public GameObject PanelDontHaveProgress;
    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider SFXSlider;
    public AudioClip ButtonPress;
    // Start is called before the first frame update
    void Awake()
    {
        SaveManager.Load();
    }
    void Start()
    {
        if(uIMainMenu == null)
        {
            uIMainMenu = this;
        }
        settingPanel.SetActive(false);
        var progress = SaveManager.GetProgress(1);
        if(progress != null)
        {
            PanelHaveProgress.SetActive(true);
            PanelDontHaveProgress.SetActive(false);
        }else
        {
            PanelHaveProgress.SetActive(false);
            PanelDontHaveProgress.SetActive(true);
        }
        SetSlider();
    }

    public void StartGame()
    {
        AudioManager.audioManager.PlaySFX(ButtonPress);
        SceneManager.LoadScene("ChoseLevel");
    }

    public void NewGame()
    {
        AudioManager.audioManager.PlaySFX(ButtonPress);
        SaveManager.RemoveData();
        SceneManager.LoadScene("ChoseLevel");
    }

    public void ExitGame()
    {
        AudioManager.audioManager.PlaySFX(ButtonPress);
        Application.Quit();
    }

    public void SettingPanelOpen()
    {
        AudioManager.audioManager.PlaySFX(ButtonPress);
        settingPanel.SetActive(true);
    }

    public void SettingPanelClose()
    {
        AudioManager.audioManager.PlaySFX(ButtonPress);
        settingPanel.SetActive(false);
        PlayerPrefs.Save();
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

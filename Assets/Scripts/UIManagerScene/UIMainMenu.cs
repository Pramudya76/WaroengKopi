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
        SceneManager.LoadScene("ChoseLevel");
    }

    public void NewGame()
    {
        SaveManager.RemoveData();
        SceneManager.LoadScene("ChoseLevel");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingPanelOpen()
    {
        settingPanel.SetActive(true);
    }

    public void SettingPanelClose()
    {
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
    }
}

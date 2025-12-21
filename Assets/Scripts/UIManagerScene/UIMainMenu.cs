using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public static UIMainMenu uIMainMenu {get; private set;}
    public GameObject settingPanel;
    // Start is called before the first frame update
    void Start()
    {
        if(uIMainMenu == null)
        {
            uIMainMenu = this;
        }
        settingPanel.SetActive(false);
    }

    public void StartGame()
    {
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
    }
}

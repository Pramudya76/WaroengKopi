using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInGame : MonoBehaviour
{
    public static UIInGame uIInGame;
    public GameObject PausedPanel;
    public GameObject SettingPanel;
    // Start is called before the first frame update
    void Start()
    {
        if(uIInGame == null)
        {
            uIInGame = this;
        }
        PausedPanel.SetActive(false);
        SettingPanel.SetActive(false);
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
    }

    public void Exit()
    {
        SceneManager.LoadScene("ChoseLevel");
    }
}

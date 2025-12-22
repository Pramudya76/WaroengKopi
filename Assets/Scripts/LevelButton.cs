using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public LvButtonData buttonData;
    public GameObject Button1Star;
    public GameObject Button2Star;
    public GameObject Button3Star;
    public GameObject Button0Star;
    public GameObject Locked;
    private Button button;
    public TextMeshProUGUI textLv;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(SelectLevel);
        ApplyData();
    }
    public void SelectLevel()
    {
        // if (buttonData == null)
        // {
        //     Debug.LogError("buttonData NULL", this);
        //     return;
        // }

        // if (GameManager.GM == null)
        // {
        //     Debug.LogError("GameManager.GM NULL");
        //     return;
        // }
        GameManager.GM.SetCurrentLevel(buttonData);
        var progres = SaveManager.GetProgress(buttonData.levelID);
        
        if(progres == null || !progres.unlocked) return;
        SceneManager.LoadScene("InGame");
    }

    void ApplyData()
    {
        var progres = SaveManager.GetProgress(buttonData.levelID);

        bool unlocked = progres!= null && progres.unlocked;
        int starCount = progres != null ? progres.Star : 0;
        
        Locked.SetActive(!unlocked);
        Button0Star.SetActive(false);
        Button1Star.SetActive(false);
        Button2Star.SetActive(false);
        Button3Star.SetActive(false);

        if(unlocked)
        {
            if(starCount == 0) Button0Star.SetActive(true);
            else if(starCount == 1) Button1Star.SetActive(true);
            else if(starCount == 2) Button2Star.SetActive(true);
            else if(starCount == 3) Button3Star.SetActive(true);
        }
        textLv.text = "Lv " + buttonData.levelID;
        button.interactable = unlocked;
    }
    
}

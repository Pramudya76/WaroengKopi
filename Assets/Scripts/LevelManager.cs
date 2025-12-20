using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager LM {get; private set;}
    private LvButtonData LvData;
    private int Score;
    private float TimeLeft;
    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI textScore;
    public GameObject PanelGameFinished;
    // Start is called before the first frame update
    void Start()
    {
        if(LM == null)
        {
            LM = this;
        }
        LvData = GameManager.lvData;
        TimeLeft = LvData.LevelDuration;
        PanelGameFinished.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        textTimer.text = "Timer : " + (int)TimeLeft;
        textScore.text = "Score : " + Score;
        if(TimeLeft <= 0)
        {
            SaveManager.SaveResult(LvData.levelID, Score, LvData);
            PanelGameFinished.gameObject.SetActive(true);
            Time.timeScale = 0;
            SceneManager.LoadScene("ChoseLevel");
        }
    } 

    public void AddScore(int score)
    {
        Score += score;
        
    }
}

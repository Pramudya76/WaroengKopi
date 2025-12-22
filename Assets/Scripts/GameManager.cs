using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM {get; private set;}
    public static LvButtonData lvData {get; private set;}
    private int totalScore;
    void Awake()
    {
        if(GM == null)
        {
            GM = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentLevel(LvButtonData lvButtonData)
    {
        lvData = lvButtonData;
    }

    // public void AddTotalScore(int score)
    // {
    //     totalScore += score;
    // }

    // public int GetTotalScore()
    // {
    //     return totalScore;
    // }
}

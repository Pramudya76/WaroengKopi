using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBtnData", menuName = "Button/BtnData")]
public class LvButtonData : ScriptableObject
{
    [Header("Level Data")]
    public int levelID;
    public float LevelDuration;
    [Header("Star Requirement")]
    public float star3Score;
    public float star2Score;
    public float star1Score;
}

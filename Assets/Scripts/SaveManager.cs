using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class LevelProgress
{
    public int levelID;
    public int BestScores;
    public int Star;
    public bool unlocked;
}

[System.Serializable]
public class SaveData
{
    public List<LevelProgress> levels;
}

public class SaveManager
{
    public static List<LevelProgress> levelProgresses = new();
    private static string savePath = Application.persistentDataPath + "/Data.json";
    public static LevelProgress SaveResult(int levelID, int newScore, LvButtonData lvData)
    {
        var lv = levelProgresses.Find(i => i.levelID == levelID);

        if(lv == null)
        {
            lv = new LevelProgress
            {
                levelID = levelID,
                unlocked = true
            };
            levelProgresses.Add(lv);
        }

        if(newScore > lv.BestScores)
        {
            lv.BestScores = newScore;
        }

        if(lv.BestScores >= lvData.star3Score) lv.Star = 3;
        else if(lv.BestScores >= lvData.star2Score) lv.Star = 2;
        else if(lv.BestScores >= lvData.star1Score) lv.Star = 1;

        var next = GetProgress(lvData.levelID + 1);
        if(next != null && !next.unlocked)
        {
            next.unlocked = true;
        }
        Save();
        return lv;
    }

    public static void SetLevel(List<LvButtonData> allLevels)
    {
        if(levelProgresses.Count > 0) return;

        foreach(var lv in  allLevels)
        {
            levelProgresses.Add(new LevelProgress
            {
                levelID = lv.levelID,
                unlocked = lv.levelID == 1,
                Star = 0,
                BestScores = 0
            });
        }
    }

    public static LevelProgress GetProgress(int levelID)
    {
        return levelProgresses.Find(i => i.levelID == levelID);
    }

    public static void Save()
    {
        SaveData data =  new SaveData
        {
            levels = levelProgresses  
        };
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }

    public static void Load()
    {
        if(!File.Exists(savePath)) return;

        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        if(data != null && data.levels != null)
        {
            levelProgresses = data.levels;
        }
    }

    public static void RemoveData()
    {
        if(File.Exists(savePath))
        {
            File.Delete(savePath);
            levelProgresses.Clear();
        }
    }
}

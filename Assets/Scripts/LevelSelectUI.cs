using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectUI : MonoBehaviour
{
    public LevelButton ButtonPrefabs;
    public Transform PanelPos;
    public List<LvButtonData> allLvData; 
    // Start is called before the first frame update
    void Start()
    {
        SaveManager.Load();
        SaveManager.SetLevel(allLvData);
        foreach(var data in allLvData)
        {
            var btn = Instantiate(ButtonPrefabs, PanelPos);
            btn.buttonData = data;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

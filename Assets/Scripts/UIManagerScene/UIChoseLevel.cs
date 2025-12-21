using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIChoseLevel : MonoBehaviour
{
    public static UIChoseLevel uIChoseLevel {get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        if(uIChoseLevel == null)
        {
            uIChoseLevel = this;
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

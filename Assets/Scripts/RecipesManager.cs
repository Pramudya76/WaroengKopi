using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesManager : MonoBehaviour
{
    public List<Recipe> recipes;
    [HideInInspector] public static RecipesManager recipesManager;
    // Start is called before the first frame update
    void Awake()
    {
        if(recipesManager == null)
        {
            recipesManager = this;
        }
    }
}

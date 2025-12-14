using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropTarget
{
    public List<ItemObjects> ingredients = new();
    public GameObject IngredientsObject;
    public void addItem(ItemData item)
    {
        ingredients.Add(item.data);
        item.currentSlot = this;
        item.transform.SetParent(transform);
        item.transform.localPosition = Vector2.zero;
        if(ingredients.Count == 2)
        {
            Mix();
        }
    } 

    public void removeItem(ItemData item)
    {
        ingredients.Remove(item.data);
    }

    public bool canAccept(ItemObjects itemObjects)
    {
        if(ingredients.Count == 0) return true;
        if(ingredients.Count >= 2) return false;
        List<ItemObjects> temp = new List<ItemObjects>(ingredients);
        temp.Add(itemObjects);
        foreach(var recipe in RecipesManager.recipesManager.recipes)
        {
            if(recipe.ingrediants.Count != temp.Count) continue;
            if(recipe.ingrediants.All(r => temp.Contains(r))) return true;
        }
        return false;
    }

    public void Mix()
    {
        foreach(var recipe in RecipesManager.recipesManager.recipes)
        {
            if(recipe.ingrediants.Count != ingredients.Count) continue;
            if(recipe.ingrediants.All(r => ingredients.Contains(r)))
            {
                foreach(Transform child in transform)
                {
                    Destroy(child.gameObject);
                }
                ingredients.Clear();
                ingredients.Add(recipe.result);
                spawnResult(recipe.result);
                return;
            }
        }
    }

    public void spawnResult(ItemObjects itemObjects)
    {
        GameObject Ingredienst = Instantiate(IngredientsObject, transform.position, Quaternion.identity, transform);
        ItemData itemData = Ingredienst.GetComponent<ItemData>();
        itemData.data = itemObjects;
        itemData.currentSlot = this;
        SpriteRenderer spriteRenderer = Ingredienst.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemData.data.sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(ingredients.Count);

        // foreach(var e in ingredients)
        // {
        //     Debug.Log(e.name);
        // }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoffeeGrinder : MonoBehaviour, IDropTarget
{
    public Slot slotCoffeGrinder;
    public ItemObjects[] cupWater; 
    public ItemObjects CoffeePowder;
    public ItemObjects Coffee;
    public GameObject ResultObject;

    public Transform DropPoint => transform;

    public void addItem(ItemData data)
    {
        //slotCoffeGrinder.ingredients.Add(data.data);
        slotCoffeGrinder.ingredients.Add(CoffeePowder);
        Destroy(data.gameObject);
        StartCoroutine(cdCoffeeGrinder(3f));
    }

    private IEnumerator cdCoffeeGrinder(float duration)
    {
        yield return new WaitForSeconds(duration);
        // ItemData itemData = slotCoffeGrinder.GetComponentInChildren<ItemData>();
        // Destroy(itemData.gameObject);
        foreach(var recipe in RecipesManager.recipesManager.recipes)
        {
            if(recipe.ingrediants.Count != slotCoffeGrinder.ingredients.Count) continue;
            if(recipe.ingrediants.All(r => slotCoffeGrinder.ingredients.Contains(r)))
            {
                foreach(Transform child in slotCoffeGrinder.transform)
                {
                    Destroy(child.gameObject);
                }
                slotCoffeGrinder.ingredients.Clear();
                spawnResult(recipe.result);
                yield break;
            }
        }
    }

    public void spawnResult(ItemObjects itemObjects)
    {
        GameObject resultBlackCoffee = Instantiate(ResultObject, slotCoffeGrinder.transform.position, Quaternion.identity, slotCoffeGrinder.transform);
        ItemData itemData = resultBlackCoffee.GetComponent<ItemData>();
        itemData.data = itemObjects;
        itemData.currentSlot = slotCoffeGrinder;
        SpriteRenderer spriteRenderer = resultBlackCoffee.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemObjects.sprite;
        slotCoffeGrinder.ingredients.Add(itemObjects);
        //itemData.EnableDrag();
    }

    public bool canAccept(ItemObjects itemObjects)
    {
        if(itemObjects != Coffee) return false;
        return slotCoffeGrinder.ingredients.Any(i => cupWater.Contains(i));
    }

    public void removeItem(ItemData data)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

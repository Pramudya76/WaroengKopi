using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnIngredienst : MonoBehaviour, IPointerClickHandler
{
    public GameObject IngredientSpawnObject;
    public ItemObjects itemObjects;
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject Ingredienst = Instantiate(IngredientSpawnObject, transform.position, Quaternion.identity);
        ItemData itemData = Ingredienst.GetComponent<ItemData>();
        itemData.data = itemObjects;
        SpriteRenderer spriteRenderer = Ingredienst.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemData.data.sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}

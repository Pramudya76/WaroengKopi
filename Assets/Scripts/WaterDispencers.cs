using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDispencers : MonoBehaviour, IDropTarget
{   
    public Transform SlotWater;
    public ItemObjects Cup;
    public ItemObjects CupWater;
    public GameObject ResultObject;
    public Transform DropPoint => transform;

    public void addItem(ItemData data)
    {
        Destroy(data.gameObject);
        SpawnResult(CupWater);
    }

    public bool canAccept(ItemObjects itemObjects)
    {
        if(itemObjects == Cup) return true;
        return false;
    }

    public void removeItem(ItemData data)
    {
        
    }

    public void SpawnResult(ItemObjects itemObjects)
    {
        GameObject result = Instantiate(ResultObject, SlotWater.position, Quaternion.identity, SlotWater);
        ItemData data = result.GetComponent<ItemData>();
        data.data = itemObjects;
        data.currentSlot = this;
        SpriteRenderer spriteRenderer = result.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemObjects.sprite;
        result.transform.localPosition = Vector2.zero;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHeater : MonoBehaviour, IDropTarget
{
    public Transform SlotWaterHeater;
    public ItemObjects cupWater;
    public ItemObjects cupHotWater;
    public GameObject ResultObject;
    public void addItem(ItemData data)
    {
        Destroy(data.gameObject);
        StartCoroutine(cdHotWater(3f));
    }

    private IEnumerator cdHotWater(float duration)
    {
        yield return new WaitForSeconds(duration);
        spawnResult(cupHotWater);
    }

    public bool canAccept(ItemObjects itemObjects)
    {
        if(itemObjects == cupWater)
        {
            return true;
        }
        return false;
    }

    public void removeItem(ItemData data)
    {
        
    }

    public void spawnResult(ItemObjects itemObjects)
    {
        GameObject result = Instantiate(ResultObject, SlotWaterHeater.transform.position, Quaternion.identity, SlotWaterHeater);
        ItemData itemData = result.GetComponent<ItemData>();
        itemData.data = itemObjects;
        itemData.currentSlot = this;
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

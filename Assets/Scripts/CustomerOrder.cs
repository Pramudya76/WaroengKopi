using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour, IDropTarget
{
    public ItemObjects orderData;
    public Transform DropPoint => transform;

    public void addItem(ItemData data)
    {
        data.currentSlot?.removeItem(data);
        Destroy(data.gameObject);
        Debug.Log("Order berhasil");
    }

    public bool canAccept(ItemObjects itemObjects)
    {
        return itemObjects == orderData;
    }

    public void removeItem(ItemData data)
    {
        
    }

    public void CompleteOrder()
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

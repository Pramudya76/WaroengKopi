using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour, IDropTarget
{
    public ItemObjects orderData;
    public Transform DropPoint => transform;
    public Customer customer;
    public GameObject OrderCompleted;
    private bool isDone = false;
    public void addItem(ItemData data)
    {
        if(isDone) return;
        data.currentSlot?.removeItem(data);
        Destroy(data.gameObject);
        isDone = true;
        customer.CompleteOrder(this.orderData);
        Debug.Log("Order berhasil");
        OrderCompleted.gameObject.SetActive(true);
    }

    public bool canAccept(ItemObjects itemObjects)
    {
        
        return itemObjects == orderData && !isDone;
    }

    public void removeItem(ItemData data)
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        OrderCompleted.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

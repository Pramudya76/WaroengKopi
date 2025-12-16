using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public OrderSlot slot;
    public List<ItemObjects> orders = new();

    public void CompleteOrder(ItemObjects order)
    {
        orders.Remove(order);
        if(orders.Count == 0)
        {
            slot.Clear();
            Destroy(gameObject);
        }
    }
}

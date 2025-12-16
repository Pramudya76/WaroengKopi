using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSlot : MonoBehaviour
{
    public bool isOccupied => currentCustomer != null;
    public Customer currentCustomer;
    public void SetCustomer(Customer owner)
    {
        currentCustomer = owner;
        owner.slot = this;
    }

    public void Clear()
    {
        currentCustomer = null;
    }
}

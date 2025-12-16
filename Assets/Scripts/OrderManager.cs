using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public GameObject[] ordersSlotPrefabs;
    public OrderSlot[] orderSlots;
    public ItemObjects[] Menus;
    private float spawnCD = 5f;
    public Transform PosOrdersSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OrderLoop());
    }

    IEnumerator OrderLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnCD);

            OrderSlot empetySlot = GetEmpetySlot();
            if(empetySlot == null) continue;
            SpawnOrders(empetySlot);
        }
    }

    OrderSlot GetEmpetySlot()
    {
        foreach(var slot in orderSlots)
        {
            if(!slot.isOccupied) return slot;
        }
        return null;
    }

    public void SpawnOrders(OrderSlot SlotOrder)
    {
        GameObject order = Instantiate(ordersSlotPrefabs[Random.Range(0, ordersSlotPrefabs.Length)], SlotOrder.transform.position, Quaternion.identity, PosOrdersSpawn);
        Customer customer = order.GetComponent<Customer>();
        SlotOrder.SetCustomer(customer);
        foreach(var orders in order.GetComponentsInChildren<CustomerOrder>())
        {
            SpriteRenderer spriteRenderer = orders.GetComponent<SpriteRenderer>();
            ItemObjects menu = Menus[Random.Range(0, Menus.Length)];
            orders.orderData = menu;
            orders.customer = customer;
            spriteRenderer.sprite = menu.sprite;
            customer.orders.Add(orders.orderData);
        }
        
    }
}

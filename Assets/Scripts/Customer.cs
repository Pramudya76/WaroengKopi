using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public OrderSlot slot;
    public List<ItemObjects> orders = new();
    private TimerOrder timerOrder;
    public int Score;
    void Start()
    {
        timerOrder = GetComponent<TimerOrder>();
    }
    public void CompleteOrder(ItemObjects order)
    {
        orders.Remove(order);
        if(orders.Count == 0)
        {
            LevelManager.LM.AddScore(Score);
            slot.Clear();
            Destroy(gameObject, 0.01f);
            Destroy(timerOrder.sliderOrder.gameObject, 0.01f);
        }
    }

    
}

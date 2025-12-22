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
    public AudioClip OrderDone;
    public AudioClip GetMoney;
    void Start()
    {
        timerOrder = GetComponent<TimerOrder>();
    }
    public void CompleteOrder(ItemObjects order)
    {
        AudioManager.audioManager.PlaySFX(OrderDone);
        orders.Remove(order);
        if(orders.Count == 0)
        {
            AudioManager.audioManager.PlaySFX(GetMoney);
            LevelManager.LM.AddScore(Score);
            slot.Clear();
            Destroy(gameObject, 0.01f);
            Destroy(timerOrder.sliderOrder.gameObject, 0.01f);
        }
    }

    
}

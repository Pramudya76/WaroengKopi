using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // ItemData itemData = eventData.pointerDrag.GetComponent<ItemData>();
        // if(itemData == null) return;

        // if(transform.childCount == 0)
        // {
        //     itemData.parentAfterDrag = transform;
        // }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}

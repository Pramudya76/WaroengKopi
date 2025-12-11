using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemObjects data;
    [HideInInspector] public Transform parentAfterDrag;
    private Vector3 originalPos;
    Collider2D col;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Jalan");
        //transform.SetParent(transform.parent);
        //transform.SetAsLastSibling();
        originalPos = transform.position;
        col.enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
        //parentAfterDrag = transform.parent;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitSlot = Physics2D.Raycast(mousePos, Vector2.up,0.001f, layer);
        if(hitSlot.collider != null)
        {
            Debug.Log("tdk jalan");
            Slot slot = hitSlot.collider.GetComponent<Slot>();
            if(slot != null && slot.transform.childCount == 0)
            {
                transform.position = slot.transform.position;
                parentAfterDrag = slot.transform;
                transform.SetParent(slot.transform);
                col.enabled = true;
                return;
            }
        } else
        {
            Debug.Log("tdk jalan");
        }
        
        transform.position = originalPos;
        col.enabled = true;
    }

    
}

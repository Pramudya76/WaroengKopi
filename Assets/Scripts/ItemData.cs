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
    public IDropTarget currentSlot;
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
            IDropTarget target = hitSlot.collider.GetComponent<IDropTarget>();
            //Debug.Log(target.canAccept(this.data));
            if(target != null && target.canAccept(this.data))
            {

                currentSlot?.removeItem(this);
                Debug.Log("tdk jalan");
                target.addItem(this);
                col.enabled = true;

                return;
            }
        } else
        {
            //Debug.Log("tdk jalan");
        }
        
        transform.position = originalPos;
        col.enabled = true;
    }

    
}

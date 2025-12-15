using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public ItemObjects data;
    [HideInInspector] public Transform parentAfterDrag;
    private Vector3 originalPos;
    Collider2D col;
    public LayerMask layer;
    public IDropTarget currentSlot;
    private bool canDrag;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if(!canDrag) return;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;

        if(Input.GetMouseButtonUp(0))
        {
            canDrag = false;
            TryDrop();
        }
    }

    public void StartDrag()
    {
        canDrag = true;
    }

    public void EnableDrag()
    {
        canDrag = true;
        col.enabled = true;
    }

    void TryDrop()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitSlot = Physics2D.Raycast(mousePos, Vector2.up,0.001f, layer);
        if(hitSlot.collider != null)
        {
            IDropTarget target = hitSlot.collider.GetComponent<IDropTarget>();
            Debug.Log(target.canAccept(this.data));
            if(target != null && target.canAccept(this.data))
            {

                currentSlot?.removeItem(this);
                //Debug.Log("jowoiiiiii");
                target.addItem(this);
                col.enabled = true;

                return;
            }
        } 
        if(currentSlot != null)
        {
            transform.SetParent(currentSlot.DropPoint);
            transform.localPosition = Vector2.zero;
            return;
        }
        
        Destroy(gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        EnableDrag();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TryDrop();
    }
}

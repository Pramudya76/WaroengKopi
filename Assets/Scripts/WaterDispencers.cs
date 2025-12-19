using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDispencers : MonoBehaviour, IDropTarget, IProduct
{   
    //public Transform SlotWater;
    public ItemObjects Cup;
    public ItemObjects CupWater;
    public GameObject ResultObject;
    [SerializeField] private List<ItemObjects> Stok = new();
    public Transform DropPoint => transform;
    private bool Reserved;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && HasStok())
        {
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(MousePos, Vector2.zero);
            if(hit && hit.collider.gameObject == gameObject)
            {
                Reserve();
                SpawnResult(CupWater);
            }
        }
    }
    public void addItem(ItemData data)
    {
        Destroy(data.gameObject);
        if(Stok.Count > 2)
        {
            return;
        }
        Stok.Add(data.data);
    }

    public bool canAccept(ItemObjects itemObjects)
    {
        if(itemObjects == Cup) return true;
        return false;
    }

    public void removeItem(ItemData data)
    {
        
    }

    public void SpawnResult(ItemObjects itemObjects)
    {
        GameObject result = Instantiate(ResultObject, transform.position, Quaternion.identity);
        ItemData data = result.GetComponent<ItemData>();
        data.data = itemObjects;
        data.product = this;
        //data.currentSlot = this;
        SpriteRenderer spriteRenderer = result.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemObjects.sprite;
        //result.transform.localPosition = Vector2.zero;
        data.StartDrag();
    }

    public bool HasStok() => Stok.Count != 0 && !Reserved;

    public void Reserve()
    {
        Reserved = true;
    }

    public void Commit()
    {
        Stok.RemoveAt(0);
        Reserved = false;
    }

    public void Cancel()
    {
        Reserved = false;
    }
}

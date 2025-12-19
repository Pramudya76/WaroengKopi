using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class WaterHeater : MonoBehaviour, IDropTarget, IProduct
{
    //public Transform SlotWaterHeater;
    public ItemObjects cupWater;
    public ItemObjects cupHotWater;
    public GameObject ResultObject;
    [SerializeField] private List<ItemObjects> Stok = new();
    public Transform DropPoint => transform;
    private bool Reserved;
    private enum HeaterState {NotReady, Waiting, Ready};
    private HeaterState state = HeaterState.NotReady;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == HeaterState.Waiting)
        {
            StartCoroutine(cdHotWater(2f));
        }else if(state == HeaterState.Ready)
        {
            if(Input.GetMouseButtonDown(0) && HasStok())
            {
                Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(MousePos, Vector2.zero);
                if(hit && hit.collider.gameObject == gameObject)
                {
                    Reserve();
                    spawnResult(cupHotWater);
                    //state = HeaterState.NotReady;
                }
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

    private IEnumerator cdHotWater(float duration)
    {
        state = HeaterState.Waiting;
        yield return new WaitForSeconds(duration);
        state = HeaterState.Ready;
        Debug.Log("Air panas sudah siap");
    }

    public bool canAccept(ItemObjects itemObjects)
    {
        if(itemObjects == cupWater)
        {
            state = HeaterState.Waiting;
            return true;
        }
        return false;
    }

    public void removeItem(ItemData data)
    {
        
    }

    public void spawnResult(ItemObjects itemObjects)
    {
        GameObject result = Instantiate(ResultObject, transform.position, Quaternion.identity);
        ItemData itemData = result.GetComponent<ItemData>();
        itemData.data = itemObjects;
        itemData.product = this;
        //itemData.currentSlot = this;
        SpriteRenderer spriteRenderer = result.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemObjects.sprite;
        result.transform.localPosition = Vector2.zero;
        itemData.StartDrag();
    }

    public bool HasStok() => Stok.Count != 0 && !Reserved;

    public void Reserve()
    {
        Debug.Log("RESERVE");
        Reserved = true;
    }

    public void Commit()
    {
        Debug.Log("COMMIT");
        Stok.RemoveAt(0);
        Reserved = false;
        
        if(Stok.Count == 0)
        {
            state = HeaterState.NotReady;
        }
    }

    public void Cancel()
    {
        Debug.Log("CANCEL");
        Reserved = false;
    }
}

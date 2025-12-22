using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoffeeGrinder : MonoBehaviour, IDropTarget, IProduct
{
    //public Slot slotCoffeGrinder;
    public ItemObjects[] cupWater; 
    public ItemObjects CoffeePowder;
    public ItemObjects Coffee;
    public GameObject ResultObject;
    [SerializeField] private List<ItemObjects> Stok = new();
    public Transform DropPoint => transform;
    private bool Reserved;
    private enum CoffeeState {NotReady, Waiting, Ready};
    private CoffeeState state = CoffeeState.NotReady;
    private ItemObjects result;
    public AudioClip GrinderCoffee;
    private bool sfxSound = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(HasWater() + "Has Wayer");
        Debug.Log(Stok.Contains(CoffeePowder) + "Has Coffee powder");
        if(HasWater() && Stok.Contains(Coffee))
        {
            Stok.Remove(Coffee);
            Stok.Add(CoffeePowder);
            Debug.Log("1");
            state = CoffeeState.Waiting;
        }
        if(state == CoffeeState.Waiting)
        {
            Debug.Log("2");
            StartCoroutine(cdCoffeeGrinder(3f));
        }else if(state == CoffeeState.Ready)
        {
            Debug.Log("sudah jadiiiiiiiiiiiiii");
            if(Input.GetMouseButtonDown(0) && HasStok())
            {
                Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(MousePos, Vector2.zero);
                if(hit && hit.collider.gameObject == gameObject)
                {
                    
                    Reserve();
                    spawnResult(result);
                    
                }
            }
        }
    }
    public void addItem(ItemData data)
    {
        //slotCoffeGrinder.ingredients.Add(data.data);
        //slotCoffeGrinder.ingredients.Add(CoffeePowder);
        Destroy(data.gameObject);
        if(Stok.Count > 1)
        {
            return;
        }
        Stok.Add(data.data);
        
    }

    private IEnumerator cdCoffeeGrinder(float duration)
    {
        if(!sfxSound)
        {
            sfxSound = true;
            AudioManager.audioManager.PlaySFX(GrinderCoffee);
        }
        state = CoffeeState.Waiting;
        yield return new WaitForSeconds(duration);
        state = CoffeeState.Ready;
        sfxSound = false;
        MixProses();
        Debug.Log("Black Coffee sudah jadi");
    }

    private bool HasWater()
    {
        return Stok.Any(i => cupWater.Contains(i));
    }

    public void MixProses()
    {
        foreach(var recipe in RecipesManager.recipesManager.recipes)
        {
            if(recipe.ingrediants.Count != Stok.Count) continue;
            
            if(recipe.ingrediants.All(r => Stok.Contains(r)))
            {
                Stok.Clear();
                Stok.Add(recipe.result);
                result = recipe.result;
                return;
            }
        }
    }

    public void spawnResult(ItemObjects itemObjects)
    {
        GameObject resultBlackCoffee = Instantiate(ResultObject, transform.position, Quaternion.identity);
        ItemData itemData = resultBlackCoffee.GetComponent<ItemData>();
        itemData.data = itemObjects;
        itemData.product = this;
        //itemData.currentSlot = slotCoffeGrinder;
        SpriteRenderer spriteRenderer = resultBlackCoffee.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemObjects.sprite;
        //Stok.Add(itemObjects);
        itemData.StartDrag();
        //itemData.EnableDrag();
    }

    private bool WaterType(ItemObjects item)
    {
        return cupWater.Contains(item);
    }

    public bool canAccept(ItemObjects itemObjects)
    {
        if(itemObjects == Coffee) return true;
        
        if(WaterType(itemObjects)) return true;

        return false;
    }

    public void removeItem(ItemData data)
    {
        
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
        if(Stok.Count == 0)
        {
            state = CoffeeState.NotReady;
        }else
        {
            state = CoffeeState.Waiting;
        }
    }

    public void Cancel()
    {
        Reserved = false;
    }
}

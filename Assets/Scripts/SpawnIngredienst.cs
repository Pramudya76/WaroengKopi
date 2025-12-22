using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnIngredienst : MonoBehaviour
{
    public GameObject IngredientSpawnObject;
    public ItemObjects itemObjects;
    public AudioClip SpawnIngredient;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if(hit && hit.collider.gameObject == gameObject)
            {
                AudioManager.audioManager.PlaySFX(SpawnIngredient);
                SpawnAndDrag();
            }
        }
    }

    public void SpawnAndDrag()
    {
        GameObject Ingredienst = Instantiate(IngredientSpawnObject, transform.position, Quaternion.identity);
        ItemData itemData = Ingredienst.GetComponent<ItemData>();
        itemData.data = itemObjects;
        SpriteRenderer spriteRenderer = Ingredienst.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemData.data.sprite;
        itemData.StartDrag();
    }
}

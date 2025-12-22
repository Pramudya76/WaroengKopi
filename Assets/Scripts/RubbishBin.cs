using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishBin : MonoBehaviour, IDropTarget
{
    public Transform DropPoint => transform;
    public AudioClip rubbishBin;
    public void addItem(ItemData data)
    {
        //data.currentSlot?.removeItem(data);
        AudioManager.audioManager.PlaySFX(rubbishBin);
        Destroy(data.gameObject);
    }

    public bool canAccept(ItemObjects itemObjects)
    {
        return true;
    }

    public void removeItem(ItemData data)
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

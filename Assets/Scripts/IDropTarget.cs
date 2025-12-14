using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDropTarget
{
    bool canAccept(ItemObjects itemObjects);
    void addItem(ItemData data);
    void removeItem(ItemData data);
}

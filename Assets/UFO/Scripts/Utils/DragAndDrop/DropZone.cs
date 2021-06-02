using System;
using UnityEngine;

public abstract class DropZone : MonoBehaviour
{
    public abstract void DropItem(ItemDragAndDrop itemDragAndDrop);
    public abstract void GrabItem(ItemDragAndDrop itemDragAndDrop);
    public abstract bool IsDropOn { get;}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDragAndDrop : DropZone
{
    [SerializeField] private ItemDragAndDrop currentItemDragAndDrop;

    public override bool IsDropOn => currentItemDragAndDrop == null;

    public override void GrabItem(ItemDragAndDrop itemDragAndDrop)
    {
        currentItemDragAndDrop = null;
    }

    public override void DropItem(ItemDragAndDrop itemDragAndDrop)
    {
        if (IsDropOn)
        {
            currentItemDragAndDrop = itemDragAndDrop;
            itemDragAndDrop.transform.SetParent(this.transform);
            itemDragAndDrop.RectTransform.position = GetComponent<RectTransform>().position;
        }        
    }
}

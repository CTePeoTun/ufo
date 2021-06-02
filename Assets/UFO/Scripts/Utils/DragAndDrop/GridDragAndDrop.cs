using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDragAndDrop : DropZone
{
    public List<ItemDragAndDrop> ItemsOnGrid => currentItemsDragAndDrop;

    [SerializeField] private Transform content = null;
    [SerializeField] private int maxCountItems = 1;
    [SerializeField] private List<ItemDragAndDrop> currentItemsDragAndDrop = default;

    public override bool IsDropOn => currentItemsDragAndDrop.Count < maxCountItems;

    public override void DropItem(ItemDragAndDrop itemDragAndDrop)
    {
        currentItemsDragAndDrop.Add(itemDragAndDrop);
        itemDragAndDrop.transform.SetParent(content);
    }

    public override void GrabItem(ItemDragAndDrop itemDragAndDrop)
    {
        currentItemsDragAndDrop.Remove(itemDragAndDrop);
    }
}

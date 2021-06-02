using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDragAndDrop : SingletonGameobject<CanvasDragAndDrop>
{
    private Transform _upperLayer => transform;

    private ItemDragAndDrop currentItem = null;

    public void GrabItem(ItemDragAndDrop item)
    {
        currentItem = item;
        currentItem.transform.SetParent(_upperLayer);
        currentItem.transform.localScale = Vector3.one;
    }

    public void DropItem(ItemDragAndDrop item)
    {
        currentItem.transform.localScale = Vector3.one;
        currentItem = null;
    }

}

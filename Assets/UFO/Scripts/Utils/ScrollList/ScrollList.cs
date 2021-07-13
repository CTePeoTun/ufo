using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public abstract class ScrollList<TypeItem, TypeInfo>  : Pool<TypeItem> where TypeItem : ScrollItem<TypeInfo>
{
    protected List<TypeItem> items = new List<TypeItem>();
    private ScrollRect scrollRect;

    protected override void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
        base.Awake();        
    }

    public virtual void UpdateList(List<TypeInfo> infoList)
    {
        foreach (var info in infoList)
        {
            var item = GetFromPool();
            item.Init(info);
            items.Add(item);
            OnInitItem(item);
        }
    }

    protected override TypeItem CreatePoolObject()
    {
        var item = base.CreatePoolObject();
        item.transform.SetParent(scrollRect.content);
        return item;
    }

    private void OnDisable()
    {
        items.Clear();
        ReturnAllToPool();
    }

    protected abstract void OnInitItem(TypeItem item);
}

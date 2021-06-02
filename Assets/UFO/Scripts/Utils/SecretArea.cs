using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class SecretArea : MonoBehaviour, IEndDragHandler, IBeginDragHandler, IDragHandler
{
    [SerializeField] private UnityEvent callSecret = null;
    [SerializeField] private int maxIteration = 6;
    private Vector2 positionStartDrag;    
    private int iteration;
    private VectorSwipe lastVectorSwipe = VectorSwipe.Nothing;

    private enum VectorSwipe
    {
        Nothing, Horizontal, Vertical
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        positionStartDrag = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float yMov = Mathf.Abs(eventData.position.y - positionStartDrag.y);
        float xMov = Mathf.Abs(eventData.position.x - positionStartDrag.x);
        VectorSwipe vectorSwipe = xMov >= yMov ? VectorSwipe.Horizontal : VectorSwipe.Vertical;
        if (vectorSwipe != lastVectorSwipe)
        {
            iteration++;
            Debug.Log(vectorSwipe);
            if (iteration >= maxIteration)
            {
                iteration = 0;
                callSecret.Invoke();
            }
        } else
        {
            iteration = 1;
        }
        lastVectorSwipe = vectorSwipe;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

}

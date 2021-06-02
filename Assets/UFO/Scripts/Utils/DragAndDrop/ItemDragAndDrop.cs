using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDrop : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private UnityEvent OnChangeZone = null;
    public DropZone CurrentZone { get; private set; }
    public RectTransform RectTransform => GetComponent<RectTransform>();
    private CanvasDragAndDrop canvasDragAndDrop => CanvasDragAndDrop.Instance;
    private Image _image => GetComponent<Image>();

    private bool isGrabbed;
    private bool isBlocked;

    private void Awake()
    {
        CurrentZone = GetComponentInParent<DropZone>();
        CurrentZone.DropItem(this);
    }

    public void SetBlock(bool state)
    {
        isBlocked = state;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isGrabbed == false && isBlocked == false)
        {
            _image.raycastTarget = false;
            CurrentZone.GrabItem(this);
            canvasDragAndDrop.GrabItem(this);
            isGrabbed = true;
        }        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isGrabbed)
        {
            if (eventData.pointerCurrentRaycast.gameObject != null)
            {
                RectTransform.position = eventData.position;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isGrabbed)
        {
            var raycastGameobject = eventData.pointerCurrentRaycast.gameObject;
            DropZone raycastTarget = null;
            if (raycastGameobject != null)
            {
                raycastTarget = raycastGameobject.GetComponent<DropZone>();
                if (raycastTarget == null)
                {
                    var itemRaycasted = raycastGameobject.GetComponent<ItemDragAndDrop>();
                    if (itemRaycasted != null && itemRaycasted.CurrentZone.IsDropOn)
                    {
                        raycastTarget = itemRaycasted.CurrentZone;
                    }
                }
            }
            
            if (raycastTarget != null && raycastTarget.IsDropOn)
            {
                CurrentZone = raycastTarget;
                OnChangeZone.Invoke();
            }            
            CurrentZone.DropItem(this);
            canvasDragAndDrop.DropItem(this);
            _image.raycastTarget = true;
            isGrabbed = false;
        }        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       // throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // throw new System.NotImplementedException();
    }
}

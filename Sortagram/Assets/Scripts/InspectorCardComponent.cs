using UnityEngine;
using UnityEngine.EventSystems;

public class InspectorCardComponent : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler
{
    [Header("General Settings")]
    [SerializeField] private Canvas parentCanvas;
    [SerializeField] private CardComponentIcon cardComponentIconObject;

    private bool isDragging;
    private CardComponentIcon cardComponentIcon;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
        
        cardComponentIcon = Instantiate(cardComponentIconObject, parentCanvas.transform);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.GetComponent<RectTransform>(), Input.mousePosition,
            Camera.main, out var localPoint);
        cardComponentIcon.GetComponent<RectTransform>().anchoredPosition = localPoint;
        eventData.pointerDrag = cardComponentIcon.gameObject;
        cardComponentIcon.GetComponent<CardComponentDragDrop>().OnBeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData) {}
}

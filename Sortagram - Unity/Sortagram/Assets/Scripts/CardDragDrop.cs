using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(GraphicRaycaster))]
[RequireComponent(typeof(IDraggable))]
public class CardDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    [Header("General Settings")]
    [SerializeField] private Canvas parentCanvas;
    [SerializeField] private Transform parent;
    
    [Header("Drag Settings")]
    [SerializeField] private float dragAlpha = 0.6f;

    private IDraggable draggedObject;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    private Vector3 previousPosition;
    
    private void Awake()
    {
        draggedObject = GetComponent<IDraggable>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        previousPosition = transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(parentCanvas.transform);

        draggedObject.isDragging = true;
        draggedObject.isInPlace = false;
        
        canvasGroup.alpha = dragAlpha;
        canvasGroup.blocksRaycasts = false;
        canvas.overrideSorting = true;
        canvas.sortingOrder = 2;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / parentCanvas.scaleFactor;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        draggedObject.isDragging = false;
        
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        canvas.overrideSorting = false;
        //canvas.sortingOrder = 1;

        if (!draggedObject.isInPlace && !draggedObject.isPending)
        {
            transform.SetParent(parent);
            //transform.position = previousPosition;
        }

        //previousPosition = transform.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        //draggedObject.isDragging = false;
    }
}

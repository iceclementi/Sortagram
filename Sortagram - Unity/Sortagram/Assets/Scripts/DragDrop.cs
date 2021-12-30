using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(GraphicRaycaster))]
[RequireComponent(typeof(IDraggable))]
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("General Settings")]
    [SerializeField] private Canvas parentCanvas;
    
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
        draggedObject.isInPlace = false;
        canvasGroup.alpha = dragAlpha;
        canvasGroup.blocksRaycasts = false;
        canvas.sortingOrder = 2;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / parentCanvas.scaleFactor;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        canvas.sortingOrder = 1;

        if (!draggedObject.isInPlace)
        {
            transform.position = previousPosition;
        }

        previousPosition = transform.position;
        draggedObject.isInPlace = false;
    }
}

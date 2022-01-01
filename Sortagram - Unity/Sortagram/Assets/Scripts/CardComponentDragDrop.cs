using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(GraphicRaycaster))]
[RequireComponent(typeof(IDraggable))]
public class CardComponentDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
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
        parentCanvas = SceneManager.instance.parentCanvas;
        
        draggedObject = GetComponent<IDraggable>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggedObject.isDragging = true;
        draggedObject.isInPlace = false;
        
        canvasGroup.alpha = dragAlpha;
        //canvasGroup.blocksRaycasts = false;
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

        if (!draggedObject.isInPlace && !draggedObject.isPending)
        {
            Destroy(gameObject);
        }
    }
}

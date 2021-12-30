using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class CardSlot : MonoBehaviour, IDropHandler
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!eventData.pointerDrag.TryGetComponent(out SortCard draggedCard)) return;
        draggedCard.transform.SetParent(transform);
        draggedCard.GetComponent<RectTransform>().localPosition = Vector3.zero;
        draggedCard.isInPlace = true;
    }
}

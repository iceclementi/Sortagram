using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(BoxCollider2D))]
public class CardSlot : MonoBehaviour
{
    [Header("Card Slot Settings")]
    [SerializeField] private Vector2 expandedSlotSize;
    [SerializeField] private Vector2 contractedSlotSize;
    
    // Components
    private CardSlotFormatter cardSlotFormatter;
    private RectTransform rectTransform;
    private BoxCollider2D triggerCollider;
    
    // States to be made private
    public bool isOccupied => transform.childCount > 0;
    public int occupiedCardId;

    // Properties
    public Vector2 size
    {
        get => cardSlotFormatter.size;
        set => cardSlotFormatter.size = value;
    }

    public Vector2 triggerSize
    {
        get => cardSlotFormatter.triggerSize;
        set => cardSlotFormatter.triggerSize = value;
    }
    
    // Events
    private void Awake()
    {
        cardSlotFormatter = GetComponent<CardSlotFormatter>();
        rectTransform = GetComponent<RectTransform>();
        triggerCollider = GetComponent<BoxCollider2D>();
    }
    
    /*public void OnDrop(PointerEventData eventData)
    {
        if (!eventData.pointerDrag.TryGetComponent(out SortCard draggedCard)) return;
        draggedCard.transform.SetParent(transform);
        draggedCard.GetComponent<RectTransform>().localPosition = Vector3.zero;
        draggedCard.isInPlace = true;
    }*/

    public void Expand() => cardSlotFormatter.Expand();
    public void Contract() => cardSlotFormatter.Contract();

    public void InsertCard(SortCard card)
    {
        occupiedCardId = card.id;
        card.transform.SetParent(transform);
        card.GetComponent<RectTransform>().localPosition = Vector3.zero;
        card.isInPlace = true;
    }
}

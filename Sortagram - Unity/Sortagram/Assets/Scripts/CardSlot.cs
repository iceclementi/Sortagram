using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(BoxCollider2D))]
public class CardSlot : MonoBehaviour
{
    // Components
    private CardSlotManager cardSlotManager;
    private CardSlotFormatter cardSlotFormatter;
    private RectTransform rectTransform;
    private BoxCollider2D triggerCollider;
    
    // States to be made private
    public bool isOccupied => transform.childCount > 0;
    public int occupiedCardId = -1;

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
        cardSlotManager = GetComponentInParent<CardSlotManager>();
        cardSlotFormatter = GetComponent<CardSlotFormatter>();
        rectTransform = GetComponent<RectTransform>();
        triggerCollider = GetComponent<BoxCollider2D>();
    }

    public void Expand() => cardSlotFormatter.Expand();
    public void Contract() => cardSlotFormatter.Contract();
    public void Format(CardSlotFormatter.CardSlotState state) => cardSlotFormatter.FormatCardSlot(state);

    public void InsertCard(SortCard card)
    {
        occupiedCardId = card.id;
        card.transform.SetParent(transform);
        card.GetComponent<RectTransform>().localPosition = Vector3.zero;
        card.isInPlace = true;
        
        cardSlotManager.FillSlot(transform.GetSiblingIndex());
    }

    public void RemoveCard()
    {
        occupiedCardId = -1;
        cardSlotManager.FreeSlot(transform.GetSiblingIndex());
    }
}

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

    // States to be made private
    public bool isOccupied => transform.childCount > 0;
    public int occupiedCardId = -1;

    // Events
    private void Awake()
    {
        cardSlotManager = GetComponentInParent<CardSlotManager>();
        cardSlotFormatter = GetComponent<CardSlotFormatter>();
    }

    public void Expand() => cardSlotFormatter.Expand();
    public void Contract() => cardSlotFormatter.Contract();
    public void Format(CardSlotFormatter.CardSlotState state) => cardSlotFormatter.FormatCardSlot(state);
    public void FormatAll() => cardSlotManager.FormatCardSlots();

    public void InsertCard(SortCard card)
    {
        occupiedCardId = card.id;
        card.EnterSlot(this);
        cardSlotManager.FillSlot(transform.GetSiblingIndex());
    }

    public void RemoveCard()
    {
        occupiedCardId = -1;
        cardSlotManager.FreeSlot(transform.GetSiblingIndex());
    }
}

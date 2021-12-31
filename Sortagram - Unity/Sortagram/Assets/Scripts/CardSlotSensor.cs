using System;
using UnityEngine;

[RequireComponent(typeof(CardSlot))]
public class CardSlotSensor : MonoBehaviour
{
    private CardSlot cardSlot;
    
    private void Awake()
    {
        cardSlot = GetComponent<CardSlot>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (cardSlot.isOccupied) return;
        if (other.GetComponent<SortCard>() == null) return;
        cardSlot.Expand();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (cardSlot.isOccupied) return;
        if (!other.TryGetComponent(out SortCard card)) return;
        card.isPending = true;
        if (!card.isDragging)
        {
            cardSlot.InsertCard(card);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent(out SortCard card)) return;
        card.isPending = false;

        if (cardSlot.isOccupied)
        {
            
        }
        else
        {
            cardSlot.Contract();
        }
    }
}

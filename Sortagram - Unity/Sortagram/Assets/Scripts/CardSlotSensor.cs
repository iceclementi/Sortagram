using System;
using UnityEngine;

[RequireComponent(typeof(CardSlot))]
public class CardSlotSensor : MonoBehaviour
{
    public bool printEnterCollisions;
    public bool printExitCollisions;
    
    private CardSlot cardSlot;
    private SortCard card;
    
    private bool isPending;
    private bool isOccupied;
    
    
    private void Awake()
    {
        cardSlot = GetComponent<CardSlot>();
    }

    private void Update()
    {
        // Edge case
        if (isOccupied && !cardSlot.isOccupied && !isPending)
        {
            cardSlot.FormatAll();
        }
        
        if (cardSlot.isOccupied || !isPending) return;
        card.isPending = true;
        
        if (isOccupied)
        {
            cardSlot.RemoveCard();
            cardSlot.Expand();
            
            card.isPending = true;
            isOccupied = false;
            isPending = true;
        }
        else if (!card.isDragging)
        {
            cardSlot.InsertCard(card);

            card.isPending = false;
            isOccupied = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (printEnterCollisions)
        {
            Debug.Log("Enter: " + other.gameObject.name);
        }
        
        if (cardSlot.isOccupied) return;
        if (!other.TryGetComponent(out SortCard enteredCard)) return;
        card = enteredCard;
        isPending = true;
        cardSlot.Expand();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (printExitCollisions)
        {
            Debug.Log("Exit: " + other.gameObject.name);
        }
        
        if (!other.TryGetComponent(out SortCard exitedCard)) return;
        card = null;
        exitedCard.isPending = false;
        isPending = false;

        if (cardSlot.isOccupied)
        {
            
        }
        else
        {
            cardSlot.Contract();
        }
    }
}

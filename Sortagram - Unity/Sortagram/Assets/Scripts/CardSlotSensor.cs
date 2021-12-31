using System;
using UnityEngine;

[RequireComponent(typeof(CardSlot))]
public class CardSlotSensor : MonoBehaviour
{
    public bool printEnterCollisions;
    public bool printStayCollisions;
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
        if (cardSlot.isOccupied || !isPending) return;
        card.isPending = true;
        
        if (isOccupied)
        {
            Debug.Log("Releasing");
            
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

    private void OnTriggerStay2D(Collider2D other)
    {
        // isPending = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (printExitCollisions)
        {
            Debug.Log("Exit: " + other.gameObject.name);
        }
        
        if (!other.TryGetComponent(out SortCard exitedCard)) return;
        isPending = false;
        card = null;
        exitedCard.isPending = false;

        if (cardSlot.isOccupied)
        {
            
        }
        else
        {
            cardSlot.Contract();
        }
    }
}

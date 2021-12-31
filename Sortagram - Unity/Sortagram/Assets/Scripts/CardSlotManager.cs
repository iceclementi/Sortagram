using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardSlotManager : MonoBehaviour
{
    [SerializeField] private CardSlot cardSlotObject;
    
    private readonly List<CardSlot> cardSlots = new List<CardSlot>();

    private readonly List<CardSlot> misplacedSlots = new List<CardSlot>(); 
    
    private bool isOnlySlot => cardSlots.Count == 1;

    private void Start()
    {
        AddSlot(0);
    }

    public void FillSlot(int index)
    {
        AddSlot(index, index + 2);
    }

    public void FreeSlot(int index)
    {
        RemoveSlot(index + 1, index - 1);
    }

    private void AddSlot(params int[] indices)
    {
        foreach (var index in indices)
        {
            var cardSlot = Instantiate(cardSlotObject, transform);
            cardSlot.transform.SetSiblingIndex(index);
            cardSlots.Insert(index, cardSlot);
        }
        
        FormatCardSlots();
    }

    private void RemoveSlot(params int[] indices)
    {
        foreach (var index in indices)
        {
            Destroy(cardSlots[index].gameObject);
            cardSlots.RemoveAt(index);
        }
        
        FormatCardSlots();
    }

    private void FormatCardSlots()
    {
        EnforceAlternate();
        
        if (isOnlySlot)
        {
            cardSlots.First().Format(CardSlotFormatter.CardSlotState.ONLY);
            return;
        }
        
        cardSlots.First().Format(CardSlotFormatter.CardSlotState.FIRST);
        cardSlots.Last().Format(CardSlotFormatter.CardSlotState.LAST);
    }

    private void EnforceAlternate()
    {
        misplacedSlots.Clear();
        var isVacantNext = true;
        
        foreach (var cardSlot in cardSlots)
        {
            if (cardSlot.isOccupied)
            {
                cardSlot.Format(CardSlotFormatter.CardSlotState.OCCUPIED);
                isVacantNext = true;
            }
            else if (isVacantNext)
            {
                cardSlot.Format(CardSlotFormatter.CardSlotState.VACANT);
                isVacantNext = false;
            }
            else
            {
                misplacedSlots.Add(cardSlot);
            }
        }

        foreach (var misplacedSlot in misplacedSlots) Destroy(misplacedSlot.gameObject);
        cardSlots.RemoveAll(misplacedSlot => misplacedSlots.Contains(misplacedSlot));
    }
}

using System;
using UnityEditor;
using UnityEngine;

public class CardSlotFormatter : MonoBehaviour
{
    [Header("Card Slot Settings")]
    [SerializeField] private Vector2 slotSize;
    [SerializeField] private Vector2 slotTriggerSize;
    
    [SerializeField] private Vector2 expandedSlotSize;
    [SerializeField] private Vector2 contractedSlotSize;
    [SerializeField] private Vector2 normalTriggerSize;
    [SerializeField] private Vector2 singleTriggerSize;
    [SerializeField] private Vector2 sideTriggerSize;
    [SerializeField] private float sideTriggerOffset;

    [Header("Components")] 
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private BoxCollider2D slotCollider;

    public enum CardSlotState { OCCUPIED, VACANT, FIRST, LAST, ONLY }
    
    private CardSlot cardSlot;

    // Properties
   

    public Vector2 size
    {
        get => slotSize;
        set => SetSize(value);
    }

    public Vector2 triggerSize
    {
        get => slotTriggerSize;
        set => SetTriggerSize(value);
    }

    #if UNITY_EDITOR
    
    private void OnValidate() => EditorApplication.delayCall += OnMyValidate;

    private void OnMyValidate()
    {
        if (this == null) return;
        SetSize(slotSize);
        SetTriggerSize(slotTriggerSize);
    }

    #endif

    private void Awake()
    {
        cardSlot = GetComponent<CardSlot>();
    }

    private void SetSize(Vector2 newSize)
    {
        slotSize = newSize;
        rectTransform.sizeDelta = newSize;
    }

    private void SetTriggerSize(Vector2 newTriggerSize)
    {
        slotTriggerSize = newTriggerSize;
        slotCollider.size = newTriggerSize;
    }

    private void SetTriggerOffset(float offset)
    {
        slotCollider.offset = new Vector2(offset, slotCollider.offset.y);
    }
    
    public void Expand()
    {
        SetSize(expandedSlotSize);
    }

    public void Contract()
    {
        SetSize(contractedSlotSize);
    }

    public void FormatCardSlot(CardSlotState state)
    {
        Debug.Log(transform.parent.childCount);

        switch (state)
        {
            case CardSlotState.OCCUPIED:
                FormatOccupiedCardSlot();
                break;
            case CardSlotState.VACANT:
                FormatVacantCardSlot();
                break;
            case CardSlotState.FIRST:
                FormatFirstCardSlot();
                break;
            case CardSlotState.LAST:
                FormatLastCardSlot();
                break;
            case CardSlotState.ONLY:
                FormatOnlyCardSlot();
                break;
            default:
                FormatVacantCardSlot();
                break;
        }
    }

    private void FormatOnlyCardSlot()
    {
        SetSize(contractedSlotSize);
        SetTriggerSize(singleTriggerSize);
        SetTriggerOffset(0);
        Debug.Log("Only");
    }
    
    private void FormatFirstCardSlot()
    {
        SetSize(contractedSlotSize);
        SetTriggerSize(sideTriggerSize);
        SetTriggerOffset(-sideTriggerOffset);
        Debug.Log("First");
    }

    private void FormatLastCardSlot()
    {
        SetSize(contractedSlotSize);
        SetTriggerSize(sideTriggerSize);
        SetTriggerOffset(sideTriggerOffset);
        Debug.Log("Last");
    }

    private void FormatOccupiedCardSlot()
    {
        SetSize(expandedSlotSize);
        SetTriggerSize(normalTriggerSize);
        SetTriggerOffset(0);
        Debug.Log("Occupied");
    }

    private void FormatVacantCardSlot()
    {
        SetSize(contractedSlotSize);
        SetTriggerSize(normalTriggerSize);
        SetTriggerOffset(0);
        Debug.Log("Vacant");
    }
}

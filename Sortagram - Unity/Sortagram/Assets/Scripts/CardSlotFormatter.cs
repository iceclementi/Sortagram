using UnityEditor;
using UnityEngine;

public class CardSlotFormatter : MonoBehaviour
{
    [Header("Card Slot Settings")]
    [SerializeField] private Vector2 slotSize;
    [SerializeField] private Vector2 slotTriggerSize;
    [SerializeField] private Vector2 expandedSlotSize;
    [SerializeField] private Vector2 contractedSlotSize;

    [Header("Components")] 
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private BoxCollider2D slotCollider;

    // Properties
    private bool isFirstSlot => transform.GetSiblingIndex() == 0;
    private bool isLastSlot => transform.GetSiblingIndex() == transform.parent.childCount - 1;
    private bool isOnlySlot => transform.parent.childCount == 1;
    
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
    
    public void Expand()
    {
        SetSize(expandedSlotSize);
    }

    public void Contract()
    {
        SetSize(contractedSlotSize);
    }

    private void FormatFirstCardSlot()
    {
        
    }

    private void FormatLastCardSlot()
    {
        
    }
}

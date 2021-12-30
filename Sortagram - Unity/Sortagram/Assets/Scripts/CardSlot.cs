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
        var draggedObject = eventData.pointerDrag;
        if (!draggedObject) return;
        draggedObject.transform.SetParent(transform);
        draggedObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
        
    }
}

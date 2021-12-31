using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Scroll Settings")]
    [SerializeField] private ScrollDirection scrollDirection;
    [SerializeField] private float scrollSpeed = 20f;
    [SerializeField] private float scrollElasticOffset = 300f;

    [Header("Components")]
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private RectTransform content;
    
    private enum ScrollDirection { LEFT, RIGHT };

    private int direction;
    private bool isScrolling;

    private void Start()
    {
        direction = scrollDirection switch
        {
            ScrollDirection.LEFT => -1,
            ScrollDirection.RIGHT => 1,
            _ => 0
        };
    }

    private void FixedUpdate()
    {
        if (!isScrolling) return;
        var delta = scrollSpeed * direction * Time.deltaTime;
        var scrollOffset = Mathf.Max(content.rect.width / 2 - scrollElasticOffset, 0f);

        var scrollPosition = Mathf.Clamp(content.anchoredPosition.x - delta, -scrollOffset, scrollOffset);
        content.anchoredPosition = new Vector3(scrollPosition, content.anchoredPosition.y);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isScrolling = true;
        scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isScrolling = false;
        scrollRect.movementType = ScrollRect.MovementType.Elastic;
    }
}

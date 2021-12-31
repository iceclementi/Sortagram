using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Scroll Settings")]
    [SerializeField] private ScrollDirection scrollDirection;
    [SerializeField] private float minScrollSpeed = 300f;
    [SerializeField] private float scrollSpeedOffset = 1200f;
    [SerializeField] private float scrollElasticOffset = 600f;

    [Header("Components")]
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private RectTransform content;
    
    private enum ScrollDirection { LEFT, RIGHT };

    private Camera mainCamera;
    private RectTransform buttonRect;
    private int direction;
    private bool isScrolling;

    private float contentWidth => content.rect.width;
    private Vector2 contentPosition
    {
        get => content.anchoredPosition;
        set => content.anchoredPosition = value;
    }

    private void Awake()
    {
        buttonRect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        mainCamera = Camera.main;
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
        var relativeSpeed = GetRelativeScrollSpeed();
        
        var delta = relativeSpeed * direction * Time.deltaTime;
        var scrollOffset = Mathf.Max(contentWidth / 2 - scrollElasticOffset, 0f);

        var scrollPosition = Mathf.Clamp(contentPosition.x - delta, -scrollOffset, scrollOffset);
        contentPosition = new Vector3(scrollPosition, contentPosition.y);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isScrolling = true;
        scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
        // Change opacity
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isScrolling = false;
        scrollRect.movementType = ScrollRect.MovementType.Elastic;
        // Change opacity
    }

    private float GetRelativeScrollSpeed()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(buttonRect, Input.mousePosition,
            mainCamera, out var localPoint);
        var scale = localPoint.x * direction / buttonRect.rect.width + 0.5f;
        return minScrollSpeed + scrollSpeedOffset * scale;
    }
}

using UnityEngine;

public class SortCard : MonoBehaviour, IDraggable
{
    [SerializeField] private int cardId;

    private RectTransform rectTransform;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void EnterSlot(CardSlot cardSlot)
    {
        transform.SetParent(cardSlot.transform);
        transform.localPosition = Vector3.zero;
        isInPlace = true;
    }

    public bool isInPlace { get; set; } = false;
    public bool isPending { get; set; } = false;
    public bool isDragging { get; set; } = false;
    public int id => cardId;
}

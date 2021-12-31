using UnityEngine;
using UnityEngine.EventSystems;

public class SortCard : MonoBehaviour, IDraggable
{
    [SerializeField] private int cardId;

    public bool isInPlace { get; set; } = false;
    public bool isPending { get; set; } = false;
    public bool isDragging { get; set; } = false;
    public int id => cardId;
}

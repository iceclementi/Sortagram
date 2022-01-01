using UnityEngine;

public class CardComponentIcon : MonoBehaviour, IDraggable
{
    [SerializeField] private int componentId;

    public bool isInPlace { get; set; } = false;
    public bool isPending { get; set; } = false;
    public bool isDragging { get; set; } = false;
    public int id => componentId;
}

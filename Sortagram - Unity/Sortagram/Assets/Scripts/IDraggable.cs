using UnityEngine;

public interface IDraggable
{
    public bool isInPlace { get; set; }
    public bool isPending { get; set; }
    public bool isDragging { get; set; }
}

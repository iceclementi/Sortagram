using UnityEngine;

public class SortCard : MonoBehaviour, IDraggable
{
    [SerializeField] private int id;

    public bool isInPlace { get; set; } = false;
    
    
}

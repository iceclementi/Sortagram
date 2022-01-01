using UnityEngine;

public class CardEditorSensor : MonoBehaviour
{
    private CardComponentIcon componentIcon;
    private CardEditor cardEditor;
    
    private bool isPending;
    private bool isOccupied;
    
    
    private void Awake()
    {
        cardEditor = GetComponent<CardEditor>();
    }

    private void Update()
    {
        if (isOccupied || !isPending) return;
        componentIcon.isPending = true;
        
        if (!componentIcon.isDragging)
        {
            componentIcon.isPending = false;
            cardEditor.Insert(componentIcon);

            isOccupied = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out CardComponentIcon enteredIcon)) return;
        componentIcon = enteredIcon;
        isPending = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent(out CardComponentIcon exitedIcon)) return;
        componentIcon = null;
        exitedIcon.isPending = false;
        isPending = false;
    }
}

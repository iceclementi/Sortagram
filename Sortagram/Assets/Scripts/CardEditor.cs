using UnityEngine;
using UnityEngine.EventSystems;

public class CardEditor : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject titleInputField;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void Insert(CardComponentIcon componentIcon)
    { 
        Instantiate(titleInputField, content);
        Destroy(componentIcon.gameObject);
    }
}

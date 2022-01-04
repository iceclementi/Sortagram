using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Card_Editor.CardComponent;

namespace Card_Editor
{
    public class CardEditorManager : MonoBehaviour
    {
        [Header("General Editor Components")]
        [SerializeField] private Transform content;
        [SerializeField] private GameObject addNewComponentOverlay;
        [SerializeField] private GameObject componentMenu;

        [Header("Card Component Prefabs")] 
        [SerializeField] private CardTitleComponent cardTitleComponentObject;

        private List<CardComponent> cardComponents = new List<CardComponent>();

        public int ActiveCardComponentIndex { get; set; } = -1;
        private int ComponentCount => cardComponents.Count;
        
        private void Start()
        {
            UpdateFormatting();
        }

        public void AddNewComponent(CardComponentType componentType)
        {
            var cardComponent = Instantiate(cardTitleComponentObject, content);
            cardComponents.Add(cardComponent);
            cardComponent.transform.SetSiblingIndex(ActiveCardComponentIndex + 1);
            
            FocusComponent(cardComponent);
        }

        public void RemoveComponent()
        {
            var removedComponent = GetCardComponentAtIndex(ActiveCardComponentIndex);
            cardComponents.Remove(removedComponent);
            Destroy(removedComponent.gameObject);

            if (ComponentCount > 0)
            {
                FocusComponent(GetCardComponentAtIndex(ActiveCardComponentIndex - 1));
            }
            else
            {
                ShowAddNewComponentOverlay();
            }
        }

        public void FocusComponent(CardComponent focussedCardComponent)
        {
            foreach (var cardComponent in cardComponents)
            {
                cardComponent.Unfocus();
            }
            
            focussedCardComponent.Focus();
            ActiveCardComponentIndex = focussedCardComponent.transform.GetSiblingIndex();
        }

        private CardComponent GetCardComponentAtIndex(int index)
        {
            return content.GetChild(index).GetComponent<CardComponent>();
        }

        private void UpdateFormatting()
        {
            addNewComponentOverlay.SetActive(ComponentCount == 0);
        }

        private void ShowAddNewComponentOverlay()
        {
            addNewComponentOverlay.SetActive(true);
            componentMenu.SetActive(false);

            ActiveCardComponentIndex = -1;
        }
    }
}

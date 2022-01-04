using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Card_Editor
{
    public abstract class CardComponent : MonoBehaviour, IPointerClickHandler
    {
        public enum CardComponentType { NONE, TITLE, TEXT_BOX, IMAGE, DIVIDER }

        protected CardEditorManager cardEditor;

        private void Start()
        {
            cardEditor = GetComponentInParent<CardEditorManager>();
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            cardEditor.FocusComponent(this);
        }

        public void Focus()
        {
            // Add highlight
        }

        public void Unfocus()
        {
            // Remove highlight
        }
    }
}

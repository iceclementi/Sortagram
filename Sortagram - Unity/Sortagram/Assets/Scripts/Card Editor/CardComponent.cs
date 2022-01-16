using Scriptable_Objects;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Card_Editor
{
    [RequireComponent(typeof(DropShadow))]
    public abstract class CardComponent : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Color highlightColor;
        
        public enum CardComponentType { NONE, TITLE, TEXT_BOX, IMAGE, DIVIDER }
        
        public CardComponentType Type { get; protected set; }
        public abstract CardComponentData Data { get; }
        protected CardEditorManager cardEditor;
        private DropShadow highlightEffect;

        private void Awake()
        {
            highlightEffect = GetComponent<DropShadow>();
            highlightEffect.enabled = false;
        }

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
            highlightEffect.enabled = true;
        }

        public void Unfocus()
        {
            highlightEffect.enabled = false;
        }
    }
}

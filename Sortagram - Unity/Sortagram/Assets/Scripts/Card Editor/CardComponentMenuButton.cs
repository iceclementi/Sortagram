using UnityEngine;
using static Card_Editor.CardComponent;

namespace Card_Editor
{
    public class CardComponentMenuButton : MonoBehaviour
    {
        [SerializeField] private CardEditorManager cardEditor;
        [SerializeField] private CardComponentType cardComponentType;

        public void AddNewComponent()
        {
            cardEditor.AddNewComponent(cardComponentType);
        }

        public void EditComponent()
        {
            
        }

        public void DeleteComponent()
        {
            cardEditor.RemoveComponent();
        }
    }
}

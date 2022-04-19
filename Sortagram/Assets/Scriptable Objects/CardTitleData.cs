using UnityEngine;
using static EditorFormatManager;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Card Title Data", menuName = "Card Component Data/Title")]
    public class CardTitleData : CardComponentData
    {
        // Content
        [Header("Content", order = 1)]
        [TextArea(1, 3)] public string title;
        
        // Settings
        [Header("Font Settings", order = 2)]
        public FontName fontName;
        public FontSize fontSize;
        public FontColor fontColor;
        public Alignment alignment;
        public bool bolded;
        public bool italicised;
        public bool underlined;

        [Header("Size Settings", order = 3)] 
        public bool autoSized;
        public float width;
        public float height;
        
        [Header("Other Settings", order = 4)] 
        public float topPadding;
        public float bottomPadding;
        public float leftPadding;
        public float rightPadding;
    }
}

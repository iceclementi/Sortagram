using UnityEngine;
using static EditorFormatManager;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Card Image Data", menuName = "Card Component Data/Image")]
    public class CardImageData : CardComponentData
    {
        // Content
        [Header("Content", order = 1)]
        [TextArea(1, 5)] public string title;
        
        // Settings
        [Header("Image Settings", order = 2)] 
        public string imagePath;
        public string alternateText;
        public Alignment alignment;
        public ImageMode imageMode;

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

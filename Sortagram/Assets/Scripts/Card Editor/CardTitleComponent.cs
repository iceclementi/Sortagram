using Scriptable_Objects;
using UnityEngine;

namespace Card_Editor
{
    public class CardTitleComponent : CardComponent
    {
        public override CardComponentData Data => TitleData;
        public CardTitleData TitleData { get; private set; }

        private void Awake()
        {
            Type = CardComponentType.TITLE;
            TitleData = ScriptableObject.CreateInstance<CardTitleData>();
        }
    }
}

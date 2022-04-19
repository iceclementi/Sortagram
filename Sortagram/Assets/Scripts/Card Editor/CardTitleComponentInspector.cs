using Scriptable_Objects;

namespace Card_Editor
{
    public class CardTitleComponentInspector : CardComponentInspector
    {
        private CardTitleComponent cardTitleComponent;
        private CardTitleData cardTitleData;
        
        public override void Initialise(CardComponent cardComponent)
        {
            cardTitleComponent = cardComponent as CardTitleComponent;
            cardTitleData = cardComponent.Data as CardTitleData;
        }
    }
}

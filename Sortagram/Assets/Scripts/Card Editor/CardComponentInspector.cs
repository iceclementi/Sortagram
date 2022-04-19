using UnityEngine;

namespace Card_Editor
{
    public abstract class CardComponentInspector : MonoBehaviour
    {
        public abstract void Initialise(CardComponent cardComponent);
    }
}

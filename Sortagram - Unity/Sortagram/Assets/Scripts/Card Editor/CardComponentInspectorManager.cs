using System;
using System.Collections.Generic;
using UnityEngine;
using static Card_Editor.CardComponent;

namespace Card_Editor
{
    public class CardComponentInspectorManager : MonoBehaviour
    {
        [SerializeField] private CardComponentInspectorMapper[] cardComponentInspectors;

        private Dictionary<CardComponentType, CardComponentInspector> inspectors;
        private CardComponentInspector activeInspector;

        private void Start()
        {
            foreach (var inspector in cardComponentInspectors)
            {
                inspectors.Add(inspector.cardComponentType, inspector.inspector);
            }
        }

        public void Inspect(CardComponent cardComponent)
        {
            ShowInspector(cardComponent.Type);
            activeInspector.Initialise(cardComponent);
        }

        private void ShowInspector(CardComponentType cardComponentType)
        {
            foreach (var inspector in inspectors.Values)
            {
                inspector.gameObject.SetActive(false);
            }

            activeInspector = GetInspectorFor(cardComponentType);
            activeInspector.gameObject.SetActive(true);
        }
        
        private CardComponentInspector GetInspectorFor(CardComponentType cardComponentType)
        {
            return inspectors.TryGetValue(cardComponentType, out var inspector) ? inspector : null;
        }
        
        [Serializable]
        private struct CardComponentInspectorMapper
        {
            public CardComponentType cardComponentType;
            public CardComponentInspector inspector;
        }
    }
}

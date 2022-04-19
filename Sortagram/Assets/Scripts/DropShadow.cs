using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropShadow : BaseMeshEffect
    {
        [SerializeField]
        private Color shadowColor = new Color(0f, 0f, 0f, 0.5f);
 
        [SerializeField]
        private Vector2 shadowDistance = new Vector2(1f, -1f);
 
        [SerializeField]
        private bool useGraphicAlpha = true;
        public int iterations = 5;
        public Vector2 shadowSpread = Vector2.one;
 
        protected DropShadow() {}
 
#if UNITY_EDITOR
        protected override void OnValidate()
        {
            EffectDistance = shadowDistance;
            base.OnValidate();
        }
 
#endif
 
        public Color EffectColor
        {
            get => shadowColor;
            set
            {
                shadowColor = value;
                if (graphic != null)
                    graphic.SetVerticesDirty();
            }
        }
 
        public Vector2 ShadowSpread
        {
            get => shadowSpread;
            set
            {
                shadowSpread = value;
                if (graphic != null)
                    graphic.SetVerticesDirty();
            }
        }
 
        public int Iterations
        {
            get => iterations;
            set
            {
                iterations = value;
                if (graphic != null)
                    graphic.SetVerticesDirty();
            }
        }
 
        public Vector2 EffectDistance
        {
            get => shadowDistance;
            set
            {
                shadowDistance = value;
 
                if (graphic != null)
                    graphic.SetVerticesDirty();
            }
        }
 
        public bool UseGraphicAlpha
        {
            get => useGraphicAlpha;
            set
            {
                useGraphicAlpha = value;
                if (graphic != null)
                    graphic.SetVerticesDirty();
            }
        }
 
 
        private void DropShadowEffect(ICollection<UIVertex> vertices)
        {
            var count = vertices.Count;
 
            var verticesCopy = new List<UIVertex>(vertices);
            vertices.Clear();
 
            for (var i = 0; i < iterations; i++)
            {
                for (var v = 0; v < count; v++)
                {
                    var vertex = verticesCopy[v];
                    var position = vertex.position;
                    var factor = i / (float) iterations;
                    position.x *= (1 + shadowSpread.x * factor * 0.01f);
                    position.y *= (1 + shadowSpread.y * factor * 0.01f);
                    position.x += shadowDistance.x * factor;
                    position.y += shadowDistance.y * factor;
                    vertex.position = position;
                    Color32 color = shadowColor;
                    color.a = (byte)((float)color.a /(float)iterations);
                    vertex.color = color;
                    vertices.Add(vertex);
                }
            }
 
            foreach (var vertex in verticesCopy)
            {
                vertices.Add(vertex);
            }
        }
 
        public override void ModifyMesh(VertexHelper vh)
        {
            if (!IsActive())
                return;
        
            var output = new List<UIVertex>();
            vh.GetUIVertexStream(output);
 
            DropShadowEffect(output);
 
            vh.Clear();
            vh.AddUIVertexTriangleStream(output);
        }
    }
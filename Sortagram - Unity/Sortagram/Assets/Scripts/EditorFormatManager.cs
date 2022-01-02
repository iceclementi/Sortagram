using System;
using UnityEngine;

public class EditorFormatManager : MonoBehaviour
{
    [SerializeField] private FontNameMapper[] fontNames;
    [SerializeField] private FontSizeMapper[] fontSizes;
    [SerializeField] private FontColorMapper[] fontColors;
    
    public enum FontName { ARIAL }
    public enum FontSize { XS, S, M, L, XL }
    public enum FontColor { RED, ORANGE, BLUE, GREY, BLACK }
    public enum Alignment { LEFT, CENTER, RIGHT, JUSTIFY }
    public enum ImageMode { FIT, STRETCH, TRUNCATE }

    [Serializable]
    private struct FontNameMapper
    {
        [SerializeField] private FontName fontName;
        [SerializeField] private Font font;
    } 
    
    [Serializable]
    private struct FontSizeMapper
    {
        [SerializeField] private FontSize fontSize;
        [SerializeField] private float size;
    } 
    
    [Serializable]
    private struct FontColorMapper
    {
        [SerializeField] private FontColor fontColor;
        [SerializeField] private Color color;
    } 
}

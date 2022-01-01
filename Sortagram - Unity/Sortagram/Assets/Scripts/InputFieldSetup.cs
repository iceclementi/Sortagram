using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class InputFieldSetup : MonoBehaviour
{
    private InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<InputField>();
    }

    private IEnumerator Start()
    {
        yield return null;
        var caret = inputField.transform.Find(inputField.name + " Input Caret");
        caret.GetComponent<CanvasRenderer>().SetMaterial(Graphic.defaultGraphicMaterial, Texture2D.whiteTexture);
    }
}

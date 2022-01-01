using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Canvas sceneParentCanvas;
    
    public static SceneManager instance { get; private set; }

    public Canvas parentCanvas => sceneParentCanvas;

    private void Awake()
    {
        instance = this;
    }
}

internal class CountText : UnityEngine.MonoBehaviour
{
    private UnityEngine.GameObject _canvas;
    private UnityEngine.GameObject _count_text;

    internal void Start()
    {
        UnityEngine.GameObject canvas_prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Canvas/canvas");
        UnityEngine.GameObject canvas_instance = Instantiate(canvas_prefab);
        _canvas= canvas_instance;
        UnityEngine.GameObject count_text_prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Canvas/count_text");
        UnityEngine.GameObject count_text_instance = Instantiate(count_text_prefab, _canvas.transform);
        _count_text= count_text_instance;
    }

    internal void Update()
    {
        
    }
}
using TMPro;
internal class CountText : UnityEngine.MonoBehaviour
{
    private UnityEngine.GameObject _canvas;
    private UnityEngine.GameObject _count_text;
    private TextMeshProUGUI _text;
    private float _count;

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
        _count += UnityEngine.Time.deltaTime;
        TextMeshProUGUI count_text = _count_text.GetComponent<TextMeshProUGUI>();
        count_text.text = "Running : " + _count.ToString("F2") + "s";
    }
}
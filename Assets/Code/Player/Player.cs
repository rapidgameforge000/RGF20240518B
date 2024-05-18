internal class Player : UnityEngine.MonoBehaviour
{
    private const int UNDER_LINE = 0;
    private const float GRAVITY = 0.1f;
    private const float JAMP_FORCE = 3.0f;

    UnityEngine.GameObject _object;
    UnityEngine.Vector2 _pos;
    UnityEngine.Vector2 _vel;

    internal void Start()
    {
        UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Player/player");
        UnityEngine.GameObject instance = UnityEngine.GameObject.Instantiate(prefab);
        _object = instance;
    }

    internal void Update()
    {
        if( _pos.y <= UNDER_LINE )
        {
            UnityEngine.Vector2 vec = new UnityEngine.Vector2(0.0f, JAMP_FORCE);
            _vel = vec; 
        }

        UnityEngine.Vector2 grabity = new UnityEngine.Vector2(0.0f, GRAVITY);
        _vel -= grabity;
        _pos += _vel;
        _object.transform.position = _pos; 
    }
}
using UnityEngine;
using static UnityEditor.PlayerSettings;

internal class Player : UnityEngine.MonoBehaviour
{
    private const int UNDER_LINE = 0;
    private const int DEAD_LINE = -600;
    private const int SIDE_LIMIT = 600;
    [SerializeField] float _gravity = 0.65f;
    [SerializeField] float _jump_force = 20.0f;
    [SerializeField] float _move_speed = 5.0f;

    UnityEngine.GameObject _object;
    UnityEngine.Vector2 _vel;

    internal void Start()
    {
        UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Player/player");
        UnityEngine.GameObject instance = UnityEngine.GameObject.Instantiate(prefab);
        _object = instance;

        _object.transform.localPosition = new Vector2(-30, 0);
    }

    internal void Update()
    {
        UnityEngine.Vector2 pos = _object.transform.localPosition;
        if( pos.y <= UNDER_LINE )
        {
            UnityEngine.Vector2 vec = new UnityEngine.Vector2(0.0f, _jump_force);
            _vel = vec; 
        }

        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.RightArrow) && pos.x <= SIDE_LIMIT)
        {
            pos.x += _move_speed;
        }
        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.LeftArrow))
        {
            pos.x -= _move_speed;
        }

        UnityEngine.Vector2 grabity = new UnityEngine.Vector2(0.0f, _gravity);
        _vel -= grabity;
        pos += _vel;
        _object.transform.localPosition = pos; 
    }

    internal bool isAlive( )
    {
        return _object.transform.localPosition.x >= DEAD_LINE;
    }
}
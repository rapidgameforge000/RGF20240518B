using UnityEngine;
using static UnityEditor.PlayerSettings;

internal class Player : UnityEngine.MonoBehaviour
{
    private const int FIRST_POS_X = 50;
    private const int FIRST_POS_Y = 0;
    private const int UNDER_LINE = -500;
    private const int DEAD_LINE = -950;
    private const int SIDE_LIMIT = 950;
    private const float GRAVITY = 0.65f;
    private const float JUMP_FORCE = 25.0f;
    private const float SPEED_FORCE = 0.5f;
    private const float SPEED_MAX = 5.0f;
    
    private UnityEngine.GameObject _object;
    private UnityEngine.Vector2 _vel;

    internal void Start()
    {
        UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Player/player");
        UnityEngine.GameObject instance = UnityEngine.GameObject.Instantiate(prefab);
        _object = instance;

        _object.transform.localPosition = new Vector2(FIRST_POS_X, FIRST_POS_Y);
    }

    internal void Update()
    {
        UnityEngine.Vector2 pos = _object.transform.localPosition;
        if( pos.y <= UNDER_LINE )
        {
            _vel.y = JUMP_FORCE; 
        }

        moveSide();

        UnityEngine.Vector2 grabity = new UnityEngine.Vector2(0.0f, GRAVITY);
        _vel -= grabity;
        pos += _vel;
        _object.transform.localPosition = pos; 
    }

    internal bool isAlive( )
    {
        return _object.transform.localPosition.x >= DEAD_LINE;
    }

    private void moveSide()
    {
        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.RightArrow) )
        {
            _vel.x += SPEED_FORCE;
            if (_vel.x >= SPEED_MAX)
            {
                _vel.x = SPEED_MAX;
            }
        }
        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.LeftArrow))
        {
            _vel.x -= SPEED_FORCE;
            if (_vel.x <= -SPEED_MAX)
            {
                _vel.x = -SPEED_MAX;
            }
        }
        if (!UnityEngine.Input.anyKey)
        {
            _vel.x *= 0.9f;
        }

        if (_object.transform.localPosition.x >= SIDE_LIMIT)
        {
            Vector2 pos = _object.transform.localPosition;
            pos.x = SIDE_LIMIT;
            _object.transform.localPosition = pos;
        }

    }
}
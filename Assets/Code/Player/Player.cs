internal class Player : UnityEngine.MonoBehaviour
{
    private const int FIRST_POS_X = 50;
    private const int FIRST_POS_Y = 0;
    private const int UNDER_LINE = -550;
    private const int DEAD_LINE = -950;
    private const int SIDE_LIMIT = 950;
    private const int UNDER_SIZE = 50;
    private const float GRAVITY = 0.65f;
    private const float JUMP_FORCE = 20.0f;
    private const float SPEED_FORCE = 0.3f;
    private const float SPEED_MAX = 10.0f;
    
    private UnityEngine.GameObject _object;
    private UnityEngine.Vector2 _vel;
    private UnityEngine.Vector2 _last_pos;

    internal void Start()
    {
        UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("Player/player");
        UnityEngine.GameObject instance = UnityEngine.GameObject.Instantiate(prefab);
        _object = instance;

        _object.transform.localPosition = new UnityEngine.Vector3(FIRST_POS_X, FIRST_POS_Y, 1.0f);
    }

    internal void Update()
    {
        _last_pos = _object.transform.localPosition;
        UnityEngine.Vector2 pos = _object.transform.localPosition;
        if( pos.y - UNDER_SIZE <= UNDER_LINE )
        {
            jump();
        }

        moveSide();
        _vel.y -= GRAVITY;
        pos += _vel;
        if (pos.x >= SIDE_LIMIT)
        {
            pos.x = SIDE_LIMIT;
        }
        _object.transform.localPosition = pos;
    }

    internal bool isAlive( )
    {
        return _object.transform.localPosition.x >= DEAD_LINE;
    }

    internal UnityEngine.Vector2 getPos()
    {
        UnityEngine.Vector2 pos = _object.transform.localPosition;
        return new UnityEngine.Vector2(pos.x, pos.y - UNDER_SIZE);
    }

    internal UnityEngine.Vector2 getLastPos()
    {
        return new UnityEngine.Vector2(_last_pos.x, _last_pos.y - UNDER_SIZE);
    }

    internal void set(UnityEngine.Vector2 pos, bool jumping)
    {
        _object.transform.localPosition = new UnityEngine.Vector2(pos.x, pos.y + UNDER_SIZE);
        if (jumping)
        {
            jump();
        }
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
    }

    private void jump()
    {
        _vel.y = JUMP_FORCE;
    }
}
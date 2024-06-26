using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Player _player;
    Block _block;
    CountText _count_text;

    // Start is called before the first frame update
    void Start()
    {
        _player= GetComponent<Player>();
        _block= GetComponent<Block>();
        _count_text= GetComponent<CountText>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_player.isAlive())
        {
            _player.enabled = false;
            _block.enabled = false;
            _count_text.enabled = false;
        }

        Vector2 pos = _player.getPos();
        Vector2 last_pos = _player.getLastPos();
        Block.RESULT result = _block.getResult(pos, last_pos);
        _player.set(result.pos, result.jumping);
    }
}

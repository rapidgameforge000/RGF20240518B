using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Player _player;
    Block _block;

    // Start is called before the first frame update
    void Start()
    {
        _player= GetComponent<Player>();
        _block= GetComponent<Block>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_player.isAlive())
        {
            _player.enabled = false;
            _block.enabled = false;
        }
    }
}

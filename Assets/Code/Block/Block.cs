using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private const int CELL_NUM = 20;
    private const int TOWER_NUM = 20;
    private const int HEIGHT_PITCH = 30;
    private const int WIDTH_PITCH = 120;
    private const int BASE_HEIGHT = -500;
    private const int BASE_WIDTH = -1100;
    private const int SCROLL_SPEED = 5;


    private struct TOWER
    {
        public GameObject[] cell;
        public int num;
    }

    public struct RESULT
    {
        public Vector2 pos;
        public bool jumping;
    }

    private TOWER[] _map;
    private int _scroll;


    void Start()
    {
        Random.InitState(10);

        createMap();
        _scroll = 0;
        adjustByScroll();

        // sample
        for (int i = 0;i < TOWER_NUM; i++)
        {
            setCellNum(i, 10);

        }
    }

    void Update()
    {
        adjustByScroll();
    }

    GameObject createPrefab()
    {
        var prefab = Resources.Load<GameObject>("Block");
        var obj = GameObject.Instantiate(prefab);
        return obj;
    }
    private void createMap()
    {
        _map = new TOWER[TOWER_NUM];

        for (int i = 0; i < TOWER_NUM; i++)
        {
            _map[i] = createTower();
        }

    }

    private TOWER createTower()
    {
        return new TOWER() { cell = createCell() };
    }

    private GameObject[] createCell()
    {
        var cell = new GameObject[HEIGHT_PITCH];
        for (int i = 0; i < CELL_NUM; i++)
        {
            var color = new Color( 0.5f - (float)(0.2 * i / CELL_NUM), 0.5f + (float)(0.5f * i / CELL_NUM), 0.2f, 1.0f);
            cell[i] = createPrefab();
            cell[i].GetComponent<Transform>().position = new Vector3(0, BASE_HEIGHT + i * HEIGHT_PITCH, i / CELL_NUM);
            cell[i].GetComponent<SpriteRenderer>().color = color;
        }
        return cell;
    }

    private void setCellNum(int towerIndex, int num)
    {
        for (int i = 0; i < CELL_NUM; i++)
        {
            _map[towerIndex].cell[i].SetActive(i < num);
        }
        _map[towerIndex].num = num;
    }

    private void setTowerPosX(int towerIndex)
    {
        for (int i = 0; i < CELL_NUM; i++)
        {
            _map[towerIndex].cell[i].GetComponent<Transform>().position = new Vector3(BASE_WIDTH + towerIndex * WIDTH_PITCH - _scroll, BASE_HEIGHT + i * HEIGHT_PITCH, (float)i / CELL_NUM);
        }
    }

    private void adjustByScroll()
    {
        _scroll += SCROLL_SPEED;
        if (_scroll >= WIDTH_PITCH ){
            _scroll -= WIDTH_PITCH;
            for (int i = 0; i < TOWER_NUM - 1; i++)
            {
                setCellNum(i, _map[i + 1].num);
            }
            setCellNum(TOWER_NUM - 1, Random.Range(1, CELL_NUM));
        }

        for (int i = 0; i < TOWER_NUM; i++)
        {
            setTowerPosX(i);
        }
        
    }

    public RESULT getResult(Vector2 playerPos, Vector2 playerLastPos)
    {
        var result = new RESULT();
        result.jumping = false;
        result.pos = playerPos;

        var x = playerPos.x - BASE_WIDTH + _scroll + WIDTH_PITCH / 2;
        var index = (int)x / WIDTH_PITCH;

        var cellHeight = _map[index].num * HEIGHT_PITCH + BASE_HEIGHT;

        if (cellHeight > playerPos.y)
        {
            if (cellHeight > playerLastPos.y)
            {
                playerLastPos.x -= SCROLL_SPEED * 2;
                result.pos = playerLastPos;

            }
            else
            {
                result.jumping = true;
                playerPos.y = cellHeight;
                result.pos = playerPos;
            }
        }

        return result;
    }
}

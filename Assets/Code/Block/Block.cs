using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private const int CELL_NUM = 10;
    private const int TOWER_NUM = 20;
    private const int HEIGHT_PICH = 50;
    private const int WIDTH_PICH = 120;
    private const int BASE_HEIGHT = -500;
    private const int BASE_WIDTH = -840;


    private struct TOWER
    {
        public GameObject[] cell;
        public int num;
    }

    private TOWER[] _map;
    private int _scroll;


    void Start()
    {
        createMap();
        adjustByScroll();
        _scroll = 0;
    }

    void Update()
    {
        _scroll++;
        _scroll %= WIDTH_PICH * TOWER_NUM;
        for (int i = 0; i < TOWER_NUM; i++)
        {
            setTowerPosX(i);
        }
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
        var cell = new GameObject[HEIGHT_PICH];
        for (int j = 0; j < CELL_NUM; j++)
        {
            var color = new Color(100 * j / CELL_NUM, 150, 200);
            cell[j] = createPrefab();
            cell[j].GetComponent<Transform>().position = new Vector2(0, BASE_HEIGHT + j * HEIGHT_PICH);
            cell[j].GetComponent<SpriteRenderer>().color = color;
        }
        return cell;
    }

    private void setCellNum(int towerIndex, int num)
    {
        for (int i = 0; i < CELL_NUM; i++)
        {
            _map[towerIndex].cell[i].SetActive(i < num);
        }
    }

    private void setTowerPosX(int towerIndex)
    {
        for (int i = 0; i < CELL_NUM; i++)
        {
            _map[towerIndex].cell[i].GetComponent<Transform>().position = new Vector2(BASE_WIDTH + towerIndex * WIDTH_PICH - _scroll, BASE_HEIGHT + i * HEIGHT_PICH);
        }
    }

    private void adjustByScroll()
    {
        for (int i = 0; i < TOWER_NUM; i++)
        {
            setCellNum(i, 10);
            setTowerPosX(i);
        }
    }
}

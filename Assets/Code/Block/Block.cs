using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private const int CELL_NUM = 10;
    private const int TOWER_NUM = 20;
    private const int HEIGHT_PICH = 50;
    private const int WIDTH_PICH = 200;
    private const int BASE_HEIGHT = -500;
    private const int BASE_WIDTH = -840; 


    private struct TOWER
    {
        public GameObject[] cell;
        public int num;
    }

    private TOWER[] _map;


    void Start()
    {
        createMap();
        adjustByScroll();
    }

    void Update()
    {

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
            cell[j] = createPrefab();
            cell[j].GetComponent<Transform>().position = new Vector2(0, BASE_HEIGHT + j * HEIGHT_PICH);
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
        for(int i = 0;i < CELL_NUM;i++)
        {
            _map[towerIndex].cell[i].GetComponent<Transform>().position = new Vector2(BASE_WIDTH + towerIndex * WIDTH_PICH, BASE_HEIGHT + i * HEIGHT_PICH);
        }
    }

    private void adjustByScroll()
    {
        for (int i = 0; i < TOWER_NUM; i++)
        {
            setCellNum(i, 3);
            setTowerPosX(i);
        }
    }
}

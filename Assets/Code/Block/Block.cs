using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    private const int HEIGHT = 10;
    private const int HEIGHT_PICH = 100;


    void Start()
    {
        create();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject createPrefab()
    {
        var prefab = Resources.Load<GameObject>("Block");
        var obj = GameObject.Instantiate(prefab);
        return obj;
    }
    private void create()
    {
        var height = new GameObject[HEIGHT];
        for (int i = 0; i < HEIGHT; i++)
        {
            height[i] = createPrefab();
            height[i].GetComponent<Transform>().position =new Vector3(0,i * HEIGHT_PICH, 0);
        }

    }
}

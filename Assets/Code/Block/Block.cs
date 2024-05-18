using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var prefab = Resources.Load<GameObject>("Block");
        var obj = GameObject.Instantiate(prefab);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

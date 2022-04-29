using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform cubePrefab;
    public ObjectPool objectPool;
    public int listSize = 10;
    private int x = 0;
    
    void Start()
    {
        for (int i = 0; i < listSize; i++)
        {
            Transform go = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            x = x + 4;
            go.transform.position = new Vector3(0, 0, x);
            objectPool.tiles.Add(go);
        }
    }

}

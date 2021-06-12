using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefab = null;
    [SerializeField]
    private float minX, maxX, minY, maxY;

    private void Awake()
    {
        Instantiate(prefab, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
    }
}

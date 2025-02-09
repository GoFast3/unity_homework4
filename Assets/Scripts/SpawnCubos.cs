using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubos : MonoBehaviour
{

    public GameObject BlockPrefab;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate a new block at the current position of SpawnCubos
            GameObject newBlock = Instantiate(BlockPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }

}
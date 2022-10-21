using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3Zadanie5 : MonoBehaviour
{
    public GameObject block;
    public int width = 10;
    public int height = 4;
    private float min = -4f;
    private float max = 5f;
    private float x;
    private float z;
    private int check;

    void Start()
    {
        List<float> blocksX = new List<float>();
        List<float> blocksZ = new List<float>();
        int i = 0;
        while (i < 10)
       {
            x = UnityEngine.Random.Range(min, max);
            z = UnityEngine.Random.Range(min, max);
            check = 0;
            for (int j=0; j<i; ++j)
            {
                if (Math.Abs(blocksX[j] - x) <= 1f && Math.Abs(blocksZ[j] - z) <= 1f)
                {
                    check = 1;
                }
            }
            if (check == 0)
            {
                blocksX.Add(x);
                blocksZ.Add(z);
                Vector3 randomSpawnPosition = new Vector3(x, 0.5f, z);
                Instantiate(block, randomSpawnPosition, Quaternion.identity);
                i++;
            }
            
       } 
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}

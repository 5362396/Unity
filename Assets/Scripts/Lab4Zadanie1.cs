using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lab4Zadanie1 : MonoBehaviour
{
    public GameObject block;
    private Vector3 min;
    private Vector3 max;
    private float x;
    private float z;
    private int check;
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int numberOfObjects = 10;
    public List<Material> myMaterial = new List<Material>();

    void Start()
    {
        List<float> blocksX = new List<float>();
        List<float> blocksZ = new List<float>();
        int i = 0;
        min = gameObject.transform.position - GetComponent<Renderer>().bounds.size / 2;
        max = gameObject.transform.position + GetComponent<Renderer>().bounds.size / 2;
        while (i < numberOfObjects)
       {
            x = UnityEngine.Random.Range(min.x + 0.5f, max.x - 0.5f);
            z = UnityEngine.Random.Range(min.z + 0.5f, max.z - 0.5f);
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
                this.positions.Add(new Vector3(x, 0.5f, z));
                i++;
            }
       } 
       StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        foreach(Vector3 pos in positions)
        {
            this.block.GetComponent<Renderer>().material = myMaterial.ElementAt((int)UnityEngine.Random.Range(0, 5));
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        StopCoroutine(GenerujObiekt());
    }

    void FixedUpdate()
    {
        
    }
}

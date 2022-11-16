using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab6Zadanie3 : MonoBehaviour
{
    public float speed = 2f;
    private bool isRunningUp = true;
    private bool isRunningDown = false;
    public List<Vector3> points = new List<Vector3>();
    private int index = 1;
    private Transform target;

    void Start()
    {
        points.Add(transform.position);
        Vector3 positionOne = new Vector3(-36.5f, 15.0f, -8.5f);
        points.Add(positionOne);
        Vector3 positionTwo = new Vector3(-30.5f, 15.0f, -8.5f);
        points.Add(positionTwo);
        Vector3 positionThree = new Vector3(-32.5f, 5f, 0f);
        points.Add(positionThree);
        var objToSpawn = new GameObject();
        target = objToSpawn.transform;
        target.transform.position = points[index];
    }

    void Update()
    {
        if (isRunningUp && Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            index++;
            if (index < points.Count)
            {
                target.transform.position = points[index];
            }
            else
            {
                isRunningDown = true;
                isRunningUp = false;
                index = index - 2;
                target.transform.position = points[index];
            }
        }
        if (isRunningDown && Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            index--;
            if (index > -1)
            {
                target.transform.position = points[index];
            }
            else
            {
                isRunningUp = true;
                isRunningDown = false;
                index = index + 2;
                target.transform.position = points[index];
            }
        }
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}

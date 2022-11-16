using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab6Zadanie2 : MonoBehaviour
{
    public float doorSpeed = 5f;
    private bool isRunning = false;
    public float distance = 3f;
    private bool isRunningUp = true;
    private bool isRunningDown = false;
    private float downPosition;
    private float upPosition;
    private Transform oldParent;

    void Start()
    {
        upPosition = transform.position.z + distance;
        downPosition = transform.position.z;
    }

    void Update()
    {
        if (isRunningUp && transform.position.z >= upPosition)
        {
            isRunning = false;
        }
        else if (isRunningDown && transform.position.z <= downPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.forward * doorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.z >= upPosition && !isRunning)
            {
                isRunningDown = true;
                isRunningUp = false;
                doorSpeed = -doorSpeed;
                Debug.Log("1");
            }
            else if (transform.position.z <= downPosition && !isRunning)
            {
                isRunningUp = true;
                isRunningDown = false;
                doorSpeed = Mathf.Abs(doorSpeed);
                Debug.Log("2");
            }
            isRunning = true;
            Debug.Log("3");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.z >= upPosition && !isRunning)
            {
                isRunningDown = true;
                isRunningUp = false;
                doorSpeed = -doorSpeed;
                Debug.Log("4");
            }
            else if (transform.position.z <= downPosition && !isRunning)
            {
                isRunningUp = true;
                isRunningDown = false;
                doorSpeed = Mathf.Abs(doorSpeed);
                Debug.Log("5");
            }
            isRunning = true;
            Debug.Log("6");
        }
    }
}

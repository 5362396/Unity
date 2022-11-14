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
            Debug.Log("Player podszedł do drzwi.");
            if (transform.position.z >= upPosition)
            {
                isRunningDown = true;
                isRunningUp = false;
                doorSpeed = -doorSpeed;
            }
            else if (transform.position.z <= downPosition)
            {
                isRunningUp = true;
                isRunningDown = false;
                doorSpeed = Mathf.Abs(doorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player odszedł od drzwi.");
            if (transform.position.z >= upPosition)
            {
                isRunningDown = true;
                isRunningUp = false;
                doorSpeed = -doorSpeed;
            }
            else if (transform.position.z <= downPosition)
            {
                isRunningUp = true;
                isRunningDown = false;
                doorSpeed = Mathf.Abs(doorSpeed);
            }
            isRunning = true;
        }
    }
}

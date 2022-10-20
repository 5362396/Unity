using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3Zadanie3 : MonoBehaviour
{
    public float speed = 2.0f;
    Rigidbody rb;
    private float startPositionX;
    private float startPositionZ;
    private int direction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPositionX = transform.position.x;
        startPositionZ = transform.position.z;
        direction = 1;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 velocityX = new Vector3(1, 0, 0);
        velocityX = velocityX.normalized * speed * Time.deltaTime;
        Vector3 velocityZ = new Vector3(0, 0, 1);
        velocityZ = velocityZ.normalized * speed * Time.deltaTime;
        Debug.Log(transform.position);
        if (transform.position.x - startPositionX < 10 && transform.position.z - startPositionZ < 10 && direction == 1)
        {
            rb.MovePosition(transform.position + velocityX);
        }
        else if (transform.position.x - startPositionX >= 10 && transform.position.z - startPositionZ < 10 && direction == 1)
        {
            direction = 2;
            transform.Rotate(0, -90, 0, Space.World);
        }
        else if (transform.position.x - startPositionX >= 10 && transform.position.z - startPositionZ < 10 && direction == 2)
        {
            rb.MovePosition(transform.position + velocityZ);
        }
        else if (transform.position.x - startPositionX >= 10 && transform.position.z - startPositionZ >= 10 && direction == 2)
        {
            direction = 3;
            transform.Rotate(0, -90, 0, Space.World);
        }
        else if (transform.position.x - startPositionX > 0 && transform.position.z - startPositionZ >= 10 && direction == 3)
        {
            rb.MovePosition(transform.position - velocityX);
        }
        else if (transform.position.x - startPositionX <= 0 && transform.position.z - startPositionZ >= 10 && direction == 3)
        {
            direction = 4;
            transform.Rotate(0, -90, 0, Space.World);
        }
        else if (transform.position.x - startPositionX <= 0 && transform.position.z - startPositionZ > 0 && direction == 4)
        {
            rb.MovePosition(transform.position - velocityZ);
        }
        else if (transform.position.x - startPositionX <= 0 && transform.position.z - startPositionZ <=0 && direction == 4)
        {
            direction = 1;
            transform.Rotate(0, -90, 0, Space.World);
        }
    }
}

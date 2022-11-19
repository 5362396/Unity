using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3Zadanie2 : MonoBehaviour
{
    public float speed = 2.0f;
    Rigidbody rb;
    private float startPosition;
    private int direction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position.x;
        direction = 1;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 velocity = new Vector3(1, 0, 0);
        velocity = velocity.normalized * speed * Time.deltaTime;
        if (transform.position.x - startPosition < 10 && direction == 1)
        {
            rb.MovePosition(transform.position + velocity);
        }
        else if (transform.position.x - startPosition >= 10 && direction == 1)
        {
            direction = 0;
        }
        else if (transform.position.x - startPosition > 0 && direction == 0)
        {
            rb.MovePosition(transform.position - velocity);
        }
        else
        {
            direction = 1;
        }
    }
}

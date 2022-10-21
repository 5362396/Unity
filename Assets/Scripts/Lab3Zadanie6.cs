using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3Zadanie6 : MonoBehaviour
{
    public float target = 2;
    public float smoothTime = 0.3f;
    private float yVelocity = 0.0f;
    public float minimum = -1.0f;
    public float maximum = 1.0f;
    static float t = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.y, target, ref yVelocity, smoothTime);
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), newPosition, transform.position.z);
        t += 0.5f * Time.deltaTime;
        if (t > 1.0f)
        {
            t = 0.0f;
        }
    }

    void FixedUpdate()
    {
        
    }
}

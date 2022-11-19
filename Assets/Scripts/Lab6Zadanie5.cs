using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab6Zadanie5 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Przeszkoda"))
        {
            Debug.Log("Gracz wszedł w kontakt z przeszkodą.");
        }
    }
}

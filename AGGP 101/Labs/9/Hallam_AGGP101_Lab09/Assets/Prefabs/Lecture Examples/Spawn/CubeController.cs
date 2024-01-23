using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    float movespeed = 25;
    float lifetime = 5; 
    void Start()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = gameObject.transform.forward * movespeed;
        rb.useGravity = false; 
        Destroy(gameObject, lifetime); 

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

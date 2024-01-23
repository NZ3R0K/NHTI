using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour
{
    public Vector3 spinSpeed;
    Transform transf;
    
    // Start is called before the first frame update
    void Start()
    {
        transf = gameObject.GetComponent<Transform>();
        Debug.Log(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinSpeed * Time.deltaTime);
    }
}

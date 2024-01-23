using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Vector3 moveDirection;
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
        transform.position = transform.position + (moveDirection * Time.deltaTime);
    }
}

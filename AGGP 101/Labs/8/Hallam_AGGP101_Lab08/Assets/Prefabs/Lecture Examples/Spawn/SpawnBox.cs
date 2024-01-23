using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    public GameObject SpawnPrefab;
    public GameObject SpawnLocation; 

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(SpawnPrefab, SpawnLocation.transform.position,
                    Quaternion.identity);
        }


    }

   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListExample : MonoBehaviour
{
    public List<GameObject> CubeList;
    public int CubeListIndex = 0; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Blitz the list to console
            foreach (GameObject cube in CubeList)
            {
                Debug.Log(cube.name); 
            }

            
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            for (int index = 0; index < CubeList.Count; index++)
            {
                //Debug.Log("i: " + index);
                //Debug.Log(CubeList[index].name);

                GameObject cube = CubeList[index];
                Debug.Log(cube.name);
            }
            // Get Previous Item in List
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Get Previous Item in List
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            CubeListIndex++;
            if (CubeListIndex >= CubeList.Count)
            {
                CubeListIndex = 0; 
            }
            Debug.Log("i: " + CubeListIndex);

            GameObject cube = CubeList[CubeListIndex];
            Debug.Log(cube.name);
        }

    }
}

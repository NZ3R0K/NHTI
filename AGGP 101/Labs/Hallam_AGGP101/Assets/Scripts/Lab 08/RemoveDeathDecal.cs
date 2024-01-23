using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDeathDecal : MonoBehaviour
{
    public float lifetime = 10;

void Start()
    {
        Destroy(gameObject, lifetime);
    }
}

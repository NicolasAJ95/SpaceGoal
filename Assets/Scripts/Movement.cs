using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        transform.position = transform.position + new Vector3(0.1f, 0, 0);
    }
}

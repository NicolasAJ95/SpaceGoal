using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] GameObject test;

    private Vector3 trans;

    void Start()
    {
        trans = test.transform.position;
    }


    void Update()
    {
        float avance = transform.position.x;
        float meta = trans.x;
        if(avance < meta)
        {
            transform.position = transform.position + new Vector3(0.1f, 0, 0);
        }
        
        
    }
}

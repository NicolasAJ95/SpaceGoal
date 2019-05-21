using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            Vector3 speed = collision.gameObject.GetComponent<Rigidbody>().velocity;
            collision.gameObject.GetComponent<Rigidbody>().velocity = speed * 1.5f;
        }
    }
}

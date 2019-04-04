using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resorte : MonoBehaviour
{
    float power;
    float minPower = 0f;
    public float maxPower = 100f;
    public Slider powerSlider;
    List<Rigidbody> shipList;
    bool shipready;

    // Start is called before the first frame update
    void Start()
    {

        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
        shipList = new List<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (shipready)
        {
            powerSlider.gameObject.SetActive(true);
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
        }

        powerSlider.value = power;

        if (shipList.Count > 0)
        {
            shipready = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if (power <= maxPower)
                {
                    power += 50 * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                foreach (Rigidbody r in shipList)
                {
                    r.AddForce(power * Vector3.forward);
                }
            }
        }
        else
        {
            shipready = false;
            power = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
            shipList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
            shipList.Add(other.gameObject.GetComponent<Rigidbody>());
            power = 0f;
        }
    }
}

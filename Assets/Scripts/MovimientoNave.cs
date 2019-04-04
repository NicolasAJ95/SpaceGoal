using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] float force;

    private Vector3 posPortal;

    bool pass;

    

    void Start()
    {
        posPortal = portal.transform.position;
        pass = false;
    }


    void Update()
    {
        if(pass == false)
        {
            float posicionNave = transform.position.x;
            float meta = posPortal.x;
            if (posicionNave <= meta)
            {
                //transform.position = transform.position + new Vector3(0.1f, 0, 0);
            }
            else
            {
                pass = true;
            }
        }
        else
        {
            float posicionNave = transform.position.x;
            float meta = force;
            if (posicionNave < meta)
            {
                //transform.position = transform.position + new Vector3(0.1f, 0, 0);
            }
                
        }
        
        
    }
}

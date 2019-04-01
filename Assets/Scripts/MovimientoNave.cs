using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    [SerializeField] GameObject portal;

    private Vector3 posPortal;

    void Start()
    {
        posPortal = portal.transform.position;
    }


    void Update()
    {
        float posicionNave = transform.position.x;
        float meta = posPortal.x;
        if(posicionNave < meta)
        {
            transform.position = transform.position + new Vector3(0.1f, 0, 0);
        }
        
    }
}

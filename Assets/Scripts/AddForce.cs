using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour

{
    [SerializeField] float force;
    [SerializeField] float MagnitudAngular;
    public Ray ClickMetter;
    public GameObject player;
    public Transform Mplayer;
    public Rigidbody NaveFisicas;
    public Vector3 PosActual;
    public Vector3 PosNext;    
    private Renderer Mrenderer;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Ship"); //almacena game object
        Mplayer = player.GetComponent<Transform>(); // Almacena el transform del object
        Mrenderer = player.GetComponent<Renderer>();
        //Mplayer.transform.position = PosActual; // Almacena pocision actual del objeto
        NaveFisicas = player.GetComponent<Rigidbody>(); // Almacena pocision actual del objeto

    }

    // Update is called once per frame
    void Update()
    {
       ObjectToThrow();
       Rotar();        
    }
    void ObjectToThrow()
    {
        if (Input.GetMouseButtonDown(0))
        {                        
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {              
               //Aca se genera una deteccion por un rayo que nace desde la camara
                if (hitInfo.collider.gameObject.CompareTag("Ship"))
                {

                    Debug.Log("Mouse is pressed down");
                    Vector3 DireccionTanque = Mplayer.forward;
                    float SentidoNave = 1f;
                    float MagnitudNave = force;
                    Vector3 FuerzaNave = MagnitudNave * DireccionTanque * SentidoNave;
                    NaveFisicas.AddForce(FuerzaNave);
                    Debug.Log("Personaje");
                     

                }
                else if (hitInfo.collider.gameObject.CompareTag("Cat"))
                {
                    Debug.Log("Cat hit");
                    
                }

            }
        }
    }
    public void Rotar()
    {
        float sentidoY = Input.GetAxis("Horizontal");
        if (sentidoY != 0)
        {
        Debug.Log(sentidoY);
        Vector3 direccionY = new Vector3(0, 1, 0);        
        Vector3 velocidadAngular = MagnitudAngular * direccionY * sentidoY;
        Vector3 desplazamientoAngular = velocidadAngular * Time.deltaTime;       
        Debug.Log(desplazamientoAngular);
        Debug.Log(velocidadAngular);
        Mplayer.eulerAngles += desplazamientoAngular;        
        }
    }
   
}
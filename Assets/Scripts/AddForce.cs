using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddForce : MonoBehaviour

{
    [SerializeField] float force;
    [SerializeField] float MagnitudAngular = 50f;
    public Ray ClickMetter;
    public GameObject player;
    public Transform Mplayer;
    public Rigidbody NaveFisicas;
    public Vector3 PosActual;
    public Vector3 PosNext;    
    private Renderer Mrenderer;
    // Slider Varibale Managment
    public float power;   
    public float minPower = 0f;
    public float maxPower = 5f;
    public Slider powerSlider;    
    bool ShipReady;
    public Text FuerzaDeEmpueje;

    //LevelEvents
    public delegate void LevelEvent();
    public static event LevelEvent MoveAction;
    public static event LevelEvent StartLevel;

    // Start is called before the first frame update
    void Start()
    {
        StartLevel();
        player = GameObject.FindWithTag("Ship"); //almacena game object
        Mplayer = player.GetComponent<Transform>(); // Almacena el transform del object
        Mrenderer = player.GetComponent<Renderer>();        
        NaveFisicas = player.GetComponent<Rigidbody>(); // Almacena pocision actual del objeto        
        powerSlider.minValue = 0f; //Slider Valor Minimo
        powerSlider.maxValue = 1500; //Slider Valor Maximo 
        
    }    
    void Update()
    {
        Debug.Log(power);
        FuerzaDeEmpueje.text = power.ToString();
        powerSlider.value = power;
        ObjectToThrow();
        
        if (ShipReady)
        {
            powerSlider.gameObject.SetActive(true);
            power += 500 * Time.deltaTime;
            Rotar();

        }
        else
        {
            powerSlider.gameObject.SetActive(false);            
        }
        
    }
    void ObjectToThrow()
    {
        if (Input.GetMouseButtonDown(0))  
        {
            ShipReady = true;            
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {           
                if (hitInfo.collider.gameObject.CompareTag("Ship"))
                {                                          
                    MoveAction();                    
                }           
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            ShipReady = false;        
            Vector3 DireccionTanque = Mplayer.forward;
            float SentidoNave = 1f;
            float MagnitudNave = power;
            Vector3 FuerzaNave = MagnitudNave * DireccionTanque * SentidoNave;
            NaveFisicas.AddForce(FuerzaNave);
            power = 0;
        }
    }
    public void Rotar()
    {
        float sentidoY = Input.GetAxis("Horizontal");        
        Vector3 direccionY = new Vector3(0, 1, 0);        
        Vector3 velocidadAngular = MagnitudAngular * direccionY * sentidoY;
        Vector3 desplazamientoAngular = velocidadAngular * Time.deltaTime;     
        Mplayer.eulerAngles += desplazamientoAngular;  
        if (sentidoY != 0)
        {

        }
        
    }
   
}
using UnityEngine;

public class Jugador : MonoBehaviour
{
    //LevelEvents
    public delegate void LevelEvent();
    public static event LevelEvent AccionMover;
    public static event LevelEvent IniciarNivel;

    // Start is called before the first frame update
    void Start()
    {
        IniciarNivel();
    }

    private void Mover()
    {
       AccionMover();
    }
}

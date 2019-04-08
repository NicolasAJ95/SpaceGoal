using UnityEngine;

public class Jugador : MonoBehaviour
{
    //LevelEvents
    public delegate void LevelEvent();
    public static event LevelEvent MoveAction;
    public static event LevelEvent StartLevel;

    // Start is called before the first frame update
    void Start()
    {
        StartLevel();
    }

    private void Mover()
    {
       MoveAction();
    }
}

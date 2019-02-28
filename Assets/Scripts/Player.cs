using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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

    private void Move()
    {
       MoveAction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

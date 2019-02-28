using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int TurnCount;


    private void OnEnable()
    {
        Player.MoveAction += AddTurn;
        Player.MoveAction += StartLevel;
    }

    private void OnDisable()
    {
        Player.MoveAction -= AddTurn;
        Player.MoveAction -= StartLevel;
    }

    private void StartLevel()
    {
        TurnCount = 0;
    }

    private void AddTurn()
    {
        TurnCount += 1;
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

}

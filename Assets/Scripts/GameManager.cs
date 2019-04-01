using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int turnCount;


    private void OnEnable()
    {
        Jugador.AccionMover += AddTurn;
        Jugador.AccionMover += StartLevel;
    }

    private void OnDisable()
    {
        Jugador.AccionMover -= AddTurn;
        Jugador.AccionMover -= StartLevel;
    }

    private void StartLevel()
    {
        turnCount = 0;
    }

    private void AddTurn()
    {
        turnCount += 1;
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    #region Singleton

    // Implementacion del Singleton 
    private static GameManager instance;
    private GameManager() { }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameManager.Instance es nula pero se esta intentando accederla");
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            //Si soy la primera instancia, hacerme el Singleton
            instance = this;
            //Descomentar esta linea si el singleton debe persistir entre escenas
            //DontDestroyOnLoad(this);
        }
        else
        {
            //Si ya existe este singleton en la escena entonces destruir este objeto 
            if (this != instance)
                DestroyImmediate(this.gameObject);
        }
    }

    #endregion
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int turnCount;
    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private Text levelScore;

    private void OnEnable()
    {
        AddForce.MoveAction += AddTurn;
        AddForce.StartLevel += StartLevel;
    }

    private void OnDisable()
    {
        AddForce.MoveAction -= AddTurn;
        AddForce.StartLevel -= StartLevel;
    }

    private void StartLevel()
    {
        turnCount = 0;
        levelScore.text = turnCount.ToString();
        ActivateGameOverUI(false);
        Time.timeScale = 1;
    }

    private void AddTurn()
    {
        turnCount += 1;
        levelScore.text = turnCount.ToString();
    }

    public void ActivateGameOverUI(bool _active)
    {
        gameOverUI.SetActive(_active);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

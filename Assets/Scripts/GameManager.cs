using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameState _gameState = GameState.GAMESTART;
    float _localTimer; //timer local to the game manager, only increases when no minigame is played
     //currently in a minigame
    public static int cashScore; //Total cash gained
    public static int lives = 4; //lives remaining
    public static float speedUpModifier = 1; //modifier to determine how fast a minigame is played

    [SerializeField] GameObject _gameStartDisplay;
    [SerializeField] GameObject _gameTransitionDisplay;
    [SerializeField] GameObject _gameWinDisplay;
    [SerializeField] GameObject _gameLoseDisplay;
    GameObject _currentStateDisplay;
    [SerializeField] GameObject[] minigames; //all minigame prefabs
    GameObject currentMinigame;

    public delegate void BeginMinigame();
    public static BeginMinigame beginMinigame;
    public delegate void WinMinigame();
    public static WinMinigame winMinigame;
    public delegate void LoseMinigame();
    public static LoseMinigame loseMinigame;
    public delegate void EndMinigame(bool isWon);
    public static EndMinigame endMinigame;

    private void OnEnable()
    {
        beginMinigame += BeginRandomMinigame;
        endMinigame += EndCurrentMinigame;
    }
    private void OnDisable()
    {
        beginMinigame -= BeginRandomMinigame;
        endMinigame -= EndCurrentMinigame;
    }

    public void BeginRandomMinigame()
    {
        _localTimer = 0;
        _gameState = GameState.MINIGAME;
        currentMinigame = GameObject.Instantiate(minigames[Random.Range(0,minigames.Length)]);
    }
    public void EndCurrentMinigame(bool isWon)
    {
        Debug.Log("MINIGAMEOVER");
        _gameState = GameState.MINIGAMEOVER;
        if (isWon)
        {
            cashScore += 10;
            winMinigame?.Invoke();
            _currentStateDisplay = Instantiate(_gameWinDisplay);
        }
        else
        {
            lives--;
            loseMinigame?.Invoke();
            _currentStateDisplay = Instantiate(_gameLoseDisplay);
        }
        Destroy(currentMinigame);
        currentMinigame = null;
        
    }

    private void Update()
    {
        switch (_gameState)
        {
            case GameState.GAMESTART:
                UpdateGameStart();
                return;
            case GameState.TRANSITION:
                UpdateTransition();
                return;
            case GameState.MINIGAME:
                return;
            case GameState.MINIGAMEOVER:
                UpdateMinigameOver();
                return;
            case GameState.GAMEOVER:
                UpdateGameOver();
                return;
        }
    }

    private void Start()
    {
        _currentStateDisplay = Instantiate(_gameStartDisplay);
    }
    void UpdateGameStart()
    {
        _localTimer += Time.deltaTime * speedUpModifier;
        if (_localTimer >= 2)
        {
            _localTimer = 0;
            Destroy(_currentStateDisplay);
            _currentStateDisplay = Instantiate(_gameTransitionDisplay);
            Debug.Log("TRANSITION");
            _gameState = GameState.TRANSITION;
        }
    }
    void UpdateTransition()
    {
        _localTimer += Time.deltaTime * speedUpModifier;
        if (_localTimer >= 2)
        {
            Destroy(_currentStateDisplay);
            _localTimer = 0;
            Debug.Log("MINIGAME");
            beginMinigame();
        }
    }
    void UpdateMinigameOver()
    {
        _localTimer += Time.deltaTime * speedUpModifier;
        if (_localTimer >= 2)
        {
            if (lives <= 0)
            {
                Debug.Log("GAMEOVER");
                _gameState = GameState.GAMEOVER;
                return;
            }
            _localTimer = 0;
            speedUpModifier += .2f;
            Debug.Log("TRANSITION");
            Destroy(_currentStateDisplay);
            _currentStateDisplay = Instantiate(_gameTransitionDisplay);
            _gameState = GameState.TRANSITION;
        }
    }
    void UpdateGameOver()
    {
        _localTimer += Time.deltaTime;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStage {LOADING, MAINMENU, GAMEPLAY, PAUSE, GAMEOVER }

public class GameController : MonoBehaviour
{
    private GameStage _gameStage;

    public GameObject EnemyPrefab, GameOverCanvas;

    private bool _gameOverTriggered;

    void Start()
    {
        _gameStage = GameStage.MAINMENU;
    }

    void Update()
    {
        if (!_gameOverTriggered)
        {
            ExecuteGameState();
        }
    }

    private void ExecuteGameState()
    {
        switch (_gameStage)
        {
            case GameStage.LOADING:
                Time.timeScale = 1;
            break;
            case GameStage.MAINMENU:
                Time.timeScale = 0;
            break;
            case GameStage.GAMEPLAY:
                Time.timeScale = 1;
                if(PlayerData.Life <= 0)
                {
                    SetGameState(4);
                }
            break;
            case GameStage.PAUSE:
                Time.timeScale = 0;
            break;
            case GameStage.GAMEOVER:
                Time.timeScale = 0;
                GameObject.Find("GameplayCanvas").SetActive(false);
                GameOverCanvas.SetActive(true);
                _gameOverTriggered = true;
            break;
        }
    }

    public void SetGameState(int index)
    {
        switch (index)
        {
            case 0:
                _gameStage = GameStage.LOADING;
            break;
            case 1:
                _gameStage = GameStage.MAINMENU;
            break;
            case 2:
                _gameStage = GameStage.GAMEPLAY;
            break;
            case 3:
                _gameStage = GameStage.PAUSE;
            break;
            case 4:
                _gameStage = GameStage.GAMEOVER;
            break;
        }
    }

    public GameStage ReturnCurrentGameState()
    {
        return _gameStage;
    }

    public void DebugAddMoneyToPlayer(int ammount)
    {
        PlayerData.Money += ammount;
    }

    public void DebugSpawnNewEnemy()
    {
        var zeroQuaternion = new Quaternion(0, 0, 0, 0);
        Instantiate(EnemyPrefab, Vector3.zero, zeroQuaternion);
    }

    public void CloseGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        //NEED FADE IN AND FADE OUT SCREEENS AAAAAAH
        SceneManager.LoadScene(0);
    }
}

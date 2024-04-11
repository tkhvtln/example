using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool IsGame { get; private set; }

    public UIController uiController;
    public SaveController saveController;
    public PlayerController playerController;

    private bool _isLoadScene;

    void Awake() 
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        saveController.Load();
        uiController.Init();
        LoadCurrentLevel();
    }

    public void Game() 
    {
        IsGame = true;
        uiController.ShowPanelGame();
    }

    public void Win()
    {
        IsGame = false;
        uiController.ShowPanelWin();
    }

    public void Defeat() 
    {
        IsGame = false;
        uiController.ShowPanelDefeat();
    }

    public void LoadCurrentLevel()
    {
        UnloadScene();
        LoadScene();
    }
    public void LoadNextLevel()
    {
        UnloadScene();

        saveController.data.level = ++saveController.data.level >= SceneManager.sceneCountInBuildSettings ? 1 : saveController.data.level;
        saveController.Save();

        LoadScene();
    }

    private void LoadScene()
    {
        if (!_isLoadScene)
        {
            _isLoadScene = true;
            SceneManager.LoadSceneAsync(saveController.data.level, LoadSceneMode.Additive);
        }

        playerController.Init();
        uiController.ShowPanelMenu();
    }

    private void UnloadScene()
    {
        if (_isLoadScene)
        {
            _isLoadScene = false;
            SceneManager.UnloadSceneAsync(saveController.data.level);
        }
    }
}

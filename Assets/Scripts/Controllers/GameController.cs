using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameController : MonoBehaviour
{
    public bool IsGame { get; private set; }

    private UIController _uiController;
    private SaveController _saveController;
    private PlayerController _playerController;

    private bool _isLoadScene;

    [Inject]
    private void Construct(PlayerController playerController, SaveController saveController, UIController uiController)
    {
        _playerController = playerController;
        _saveController = saveController;
        _uiController = uiController;

        _saveController.Load();
        LoadCurrentLevel();
    }

    public void Game() 
    {
        IsGame = true;
        _uiController.ShowPanelGame();
    }

    public void Win()
    {
        IsGame = false;
        _uiController.ShowPanelWin();
    }

    public void Defeat() 
    {
        IsGame = false;
        _uiController.ShowPanelDefeat();
    }

    public void LoadCurrentLevel()
    {
        UnloadScene();
        LoadScene();
    }
    public void LoadNextLevel()
    {
        UnloadScene();

        _saveController.data.level = ++_saveController.data.level >= SceneManager.sceneCountInBuildSettings ? 1 : _saveController.data.level;
        _saveController.Save();

        LoadScene();
    }

    private void LoadScene()
    {
        if (!_isLoadScene)
        {
            _isLoadScene = true;
            SceneManager.LoadSceneAsync(_saveController.data.level, LoadSceneMode.Additive);
        }

        _playerController.Init();
        _uiController.ShowPanelMenu();
    }

    private void UnloadScene()
    {
        if (_isLoadScene)
        {
            _isLoadScene = false;
            SceneManager.UnloadSceneAsync(_saveController.data.level);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public bool IsGame => _isGame;

    public UIController ControllerUI;
    public SaveController ControllerSave;
    public PlayerController ControllerPlayer;

    private bool _isLoadScene;
    private bool _isGame;

    void Awake() 
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        ControllerSave.Load();
        ControllerUI.Init();
        LoadCurrentLevel();
    }

    public void Game() 
    {
        _isGame = true;
        ControllerUI.ShowPanelGame();
    }

    public void Win()
    {
        _isGame = false;
        ControllerUI.ShowPanelWin();
    }

    public void Defeat() 
    {
        _isGame = false;
        ControllerUI.ShowPanelDefeat();
    }

    public void LoadCurrentLevel()
    {
        UnloadScene();
        LoadScene();

        ControllerPlayer.Init();
        ControllerUI.ShowPanelMenu();
    }
    public void LoadNextLevel()
    {
        UnloadScene();

        ControllerSave.DataPlayer.Level = ++ControllerSave.DataPlayer.Level >= SceneManager.sceneCountInBuildSettings ? 1 : ControllerSave.DataPlayer.Level;
        ControllerSave.Save();

        LoadScene();

        ControllerPlayer.Init();
        ControllerUI.ShowPanelMenu();
    }

    private void LoadScene()
    {
        if (!_isLoadScene)
        {
            _isLoadScene = true;
            SceneManager.LoadSceneAsync(ControllerSave.DataPlayer.Level, LoadSceneMode.Additive);
        }
    }

    private void UnloadScene()
    {
        if (_isLoadScene)
        {
            _isLoadScene = false;
            SceneManager.UnloadSceneAsync(ControllerSave.DataPlayer.Level);
        }
    }
}

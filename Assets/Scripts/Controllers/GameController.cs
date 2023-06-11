using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public bool IsGame => _isGame;

    public UIController ControllerUI;
    public LevelController ControllerLevel;
    public PlayerController ControllerPlayer;

    [Space] 
    public Config Config;

    private bool _isGame;
    private int _indexLevel;

    void Awake() 
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        _indexLevel = PlayerPrefs.GetInt(MyConstants.SAVE_LEVEL);

        ControllerUI.Init();
        ControllerLevel.Init();

        LoadLevel();
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

        _indexLevel++;
        PlayerPrefs.SetInt(MyConstants.SAVE_LEVEL, _indexLevel);
    }

    public void Defeat() 
    {
        _isGame = false;
        ControllerUI.ShowPanelDefeat();
    }

    public void LoadLevel() 
    {
        ControllerLevel.LoadLevel(_indexLevel);
        ControllerUI.ShowPanelMenu();
        ControllerPlayer.Init();
    }

    public void LoadNextLevel() 
    {
        ControllerLevel.LoadLevel(_indexLevel);
        ControllerUI.ShowPanelMenu();
        ControllerPlayer.Init();
    }

    [ContextMenu("Reset save")]
    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
    }
}

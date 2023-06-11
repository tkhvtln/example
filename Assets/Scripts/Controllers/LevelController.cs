using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Level CurrentLevel;
    private Config Config => GameController.Instance.Config;

    public void Init() 
    {
        
    }

    public void LoadLevel(int index = 0) 
    {
        if (CurrentLevel != null)
            Destroy(CurrentLevel.gameObject);

        CurrentLevel = Instantiate(Config.LevelList[index % Config.LevelList.Count], transform);
        CurrentLevel.Init();
    }
}

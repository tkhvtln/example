using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public Data DataPlayer;

    public void Save()
    {
        string jsonDataString = JsonUtility.ToJson(DataPlayer, true);
        PlayerPrefs.SetString(Constants.DATA, jsonDataString);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(Constants.DATA))
        {
            string loadedString = PlayerPrefs.GetString(Constants.DATA);
            DataPlayer = JsonUtility.FromJson<Data>(loadedString);
        }
        else
        {
            DataPlayer = new Data();
        }
    }
}

public class Data
{
    public bool IsSound;
    public int Coins;
    public int Level;

    public Data()
    {
        IsSound = true;
        Coins = 0;
        Level = 1;
    }
}

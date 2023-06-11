using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "TKHVTLN/Config", order = 0)]
public class Config : ScriptableObject 
{
    public List<Level> LevelList;
}
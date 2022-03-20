using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Games Data")]
public class Data : ScriptableObject
{
    public List<GameData> games = new List<GameData>();
}

[System.Serializable]
public class GameData
{
    public string name;
    public List<MatchData> data = new List<MatchData>();
}

[System.Serializable]
public class MatchData 
{
    public string part1;
    public string part2;
}

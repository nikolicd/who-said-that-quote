using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<GameManager>(true);
            }
            return _instance;
        }
    }

    public Data data;

    public List<GameData> games
    {
        get
        {
            return data.games;
        }
    }

    public List<MatchData> matchData
    {
        get
        {
            return selectedGame.data;
        }
    }

    public string[] GetRandomWrongPart2s(string part2)
    {
        string[] parts = new string[5];
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i] = GetRandomPart(part2);
        }
        return parts;
    }

    string GetRandomPart(string part2)
    {
        MatchData data;
        do
        {
            data = matchData[Random.Range(0, matchData.Count)];
        }
        while (data.part2 == part2);

        return data.part2;
    }
    public GameData selectedGame
    {
        get;
        set;
    }

    public MatchData selectedMatch
    {
        get;
        set;
    }
}

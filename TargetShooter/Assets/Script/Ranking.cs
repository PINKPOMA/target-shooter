using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[System.Serializable] 
public class RankData 
{ 
    public int score; 
    public string name;
} 

public class Ranking : Singleton<Ranking>
{
    public string playerName;
    public int playerScore;
    public RankData[] ranking = new RankData[5];

    public void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            ranking[i].score = PlayerPrefs.GetInt(i + "RankScore", ranking[i].score);
            ranking[i].name = PlayerPrefs.GetString(i + "RankName", ranking[i].name);
        }
    }

    public void SetRank(int num)
    {
        playerScore = num;
        RankData temp;
        if (playerScore > ranking[4].score)
        {
            ranking[4].score = playerScore;
            ranking[4].name = playerName;
            for (int i = 4; i > 0; i--)
            {
                while (ranking[i].score > ranking[i-1].score)
                {
                    temp = ranking[i];
                    ranking[i] = ranking[i -1];
                    ranking[i -1] = temp;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt(i + "RankScore", ranking[i].score);
                PlayerPrefs.SetString(i + "RankName", ranking[i].name);
            }
        }
    }
}

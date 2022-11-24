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
    public void SetRank(int num)
    {
        playerScore = num;
        if (playerScore < ranking[4].score) return;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("PlayerScore", playerScore);

        RankData temp;
        
        for (int i = 4; i > 0; i--)
        {
            ranking[i].score = playerScore;
            ranking[i].name = playerName;
            while (ranking[i].score > ranking[i-1].score)
            {
                temp = ranking[i];
                ranking[i] = ranking[i -1];
                ranking[i -1] = temp;


                PlayerPrefs.SetString(i +"PlayerName", playerName);
                PlayerPrefs.SetInt(i + "PlayerScore", playerScore);
            }
        }

        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(i + "RankScore", ranking[i].score);
            PlayerPrefs.SetString(i + "RankName", ranking[i].name);
        }
    }
}

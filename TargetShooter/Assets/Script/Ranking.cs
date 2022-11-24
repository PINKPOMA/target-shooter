using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;



public class Ranking : Singleton<Ranking>
{
    class JsonUtilityEx
    {
        public static T ReadData<T>(string path)
        {
            return JsonUtility.FromJson<T>(File.ReadAllText(path));
        }
    
        public static void WriteData<T>(string path, T data)
        {
            File.WriteAllText(path, JsonUtility.ToJson(data));
        }

        public static bool IsExists(string path)
        {
            return File.Exists(path);
        }

        public static T LoadData<T>(string path)
        {
            return IsExists(path) ? ReadData<T>(path) : default; 
        }
    }

    public User user;
    public string playerName;
    public int nowScore;
    public List<User> ranking = new List<User>();
    public void SetRank(int num)
    {
        Debug.Log(ranking.Count);
        nowScore = num;
        ranking = JsonUtilityEx.LoadData<List<User>>($"{Application.dataPath}/data.json");

        user.name = playerName;
        user.score = nowScore;
        Debug.Log(nowScore + " : " + playerName + " : " + user);
        ranking.Add(user);

        ranking.Sort((a, b) => a.score.CompareTo(b.score));

        var showCell = ranking.Take(5).ToList();

        JsonUtilityEx.WriteData("path/data.json", showCell);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class RankManager : MonoBehaviour
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
    public TextMeshProUGUI[] rankText;

    private void Start()
    {
        rankText = new[] { gameObject.GetComponentInChildren<TextMeshProUGUI>() };
        var jsonRanking = JsonUtilityEx.LoadData<List<(string name, int score)>>($"{Application.dataPath}/data.json");

        for (int i = 1; i <= 5; i++)
        {
//            rankText[i - 1].text = $"{i}# {jsonRanking[i - 1].name}({jsonRanking[i - 1].score})";
        }
    }
}

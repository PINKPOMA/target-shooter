using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    public TextMeshProUGUI[] rankText;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            rankText[i].text = $"{i + 1}# {Ranking.Instance.ranking[i].name}({Ranking.Instance.ranking[i].score})";
        }
    }
}

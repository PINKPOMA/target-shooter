using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    public GameObject inputField_Name;
    public GameObject rankObject;

    private void Start()
    {
        Debug.Log($"{Application.dataPath}/data.json");
    }

    public void StartButton()
    {
        SceneManager.LoadScene("InGame");
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void EnterName()
    {
        playerNameText.text = $"player: {inputField_Name.GetComponent<TMP_InputField>().text}";
        Ranking.Instance.playerName = inputField_Name.GetComponent<TMP_InputField>().text;
    }

    public void RankButton()
    {
        rankObject.SetActive(true);
    }
}

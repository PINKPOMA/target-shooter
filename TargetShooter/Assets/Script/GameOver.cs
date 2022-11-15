using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI gameOverText;
    [SerializeField]private Image exitButton;
    [SerializeField]private Image reStartButton;
    private string _contentText;
    private string _subText;
    void Start()
    {
        _contentText = "GameOver";
        StartCoroutine(TypingAction());
    }

    IEnumerator TypingAction()
    {
        yield return new WaitForSeconds(0.5f);
        for(int i = 0; i <= _contentText.Length; i++)
        {

            yield return new WaitForSeconds(0.3f);
            _subText += _contentText.Substring(0,i);
            gameOverText.text = _subText;
            _subText = "";
            if (i == 4)
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
        yield return new WaitForSeconds(0.5f);
        gameOverText.transform.DOLocalMoveY(300, 1f);
        yield return new WaitForSeconds(1f);
        exitButton.DOFade(1, 1f);
        reStartButton.DOFade(1, 1f);
    }


    public void ReStart()
    {
        SceneManager.LoadScene("InGame");
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{
    [SerializeField] TMP_InputField input;
    [SerializeField] Text bestScoreText;

    private void Start()
    {
        if (PlayerManager.Instance != null)
        {
            bestScoreText.text = $"Best Score: {PlayerManager.Instance.BestPlayer} : " +
                $"{PlayerManager.Instance.BestScore}";
        }
    }
    public void StartNew()
    {
        PlayerManager.Instance.CurrentPlayerName = input.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

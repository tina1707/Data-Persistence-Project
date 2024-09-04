using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] Text bestScoreText;
    [SerializeField] TextMeshProUGUI currentPlayerNameText; 
    // Start is called before the first frame update
    private void Awake()
    {
        if (PlayerManager.Instance != null)
        {
            currentPlayerNameText.text = PlayerManager.Instance.CurrentPlayerName;
            UpdateBestScore();
        }
    }
    public void UpdateBestScore()
    {
        PlayerManager.Instance.LoadBestScore();
        bestScoreText.text = $"Best Score: {PlayerManager.Instance.BestPlayer} : " +
            $"{PlayerManager.Instance.BestScore}";
    }
}

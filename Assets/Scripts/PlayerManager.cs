using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public int BestScore;
    public string BestPlayer = "";

    public string CurrentPlayerName { get; set; }

    private void Awake()
    {
        if(Instance==null)
        {
            Instance= this;
            DontDestroyOnLoad(gameObject);
            LoadBestScore();
            return;
        }
        Destroy(gameObject);
    }
    [Serializable]
    public class PlayerRecord
    {
        public string Name;
        public int Score;
        
    }

    public void SaveBestScore()
    {
        BestPlayer = CurrentPlayerName;
        PlayerRecord player = new PlayerRecord() { Name = BestPlayer, Score = BestScore };

        string json = JsonUtility.ToJson(player);

        File.WriteAllText(Application.persistentDataPath + "/best_score.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/best_score.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);

            PlayerRecord player = JsonUtility.FromJson<PlayerRecord>(json);
            BestPlayer = player.Name;
            BestScore = player.Score;
        }
    }
}

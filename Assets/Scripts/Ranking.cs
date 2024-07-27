using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    public static Ranking Instance;
    public int BestScore;
    public string BestPlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameRank();
    }
  

    private void SetBestPlayer()
    {
        
            BestPlayer = string.Empty;
            BestScore = 0;
           
    }

    public void LoadGameRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            if (data != null)
            {
                BestPlayer = data.TheBestPlayer;
                BestScore = data.HighiestScore;
                
            }
            else
            {
                SetBestPlayer();
            }
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int HighiestScore;
        public string TheBestPlayer;
    }
}




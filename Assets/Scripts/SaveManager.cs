using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public string highScoreName;
    public string playerName;
    public int highScore;

   void Awake()
   {
       if (Instance != null)
       {
        Destroy(gameObject);
        return;
       }

       Instance = this;
       DontDestroyOnLoad(gameObject);

       LoadHighScore();
   }

   [System.Serializable]
   class SaveData
   {
    public int highScore;
    public string highScoreName;
   }

   public void SaveHighScore()
   {
    SaveData data = new SaveData();
    data.highScore = highScore;
    data.highScoreName = highScoreName;

    string json = JsonUtility.ToJson(data);

    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
   }

   public void LoadHighScore()
   {
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        highScoreName = data.highScoreName;
        highScore = data.highScore;
    }
   }
}

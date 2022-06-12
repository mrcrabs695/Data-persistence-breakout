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
   }
}

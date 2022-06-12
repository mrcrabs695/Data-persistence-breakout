using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI inputText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = ("High Score: " + SaveManager.Instance.highScoreName + " : " + SaveManager.Instance.highScore);
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        SaveManager.Instance.playerName = inputText.text;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Name is: " + SaveManager.Instance.playerName);
        }
    }
}

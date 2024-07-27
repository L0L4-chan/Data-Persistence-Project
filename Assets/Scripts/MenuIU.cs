using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuIU : MonoBehaviour
{
    [SerializeField] TMP_InputField PlayerInputName;
    [SerializeField] string UserName;
    [SerializeField] TMP_Text position1;
   // [SerializeField] TMP_Text position2;
    //[SerializeField] TMP_Text position3;
    // 
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // 
    private void Start()
    {
        string BestPlayer = Ranking.Instance.BestPlayer;
        string BestScore = Ranking.Instance.BestScore.ToString();
        position1.text = $"1 - {BestPlayer}: {BestScore}"; ;
        
    }
    public void SetPlayerName()
    {
        UserData.Instance.userName = PlayerInputName.text;    
        UserName = PlayerInputName.text;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

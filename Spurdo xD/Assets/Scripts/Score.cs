using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score Instance;
    [Header("UI-TextBoxs")]
    public TMP_Text uiScore;
    public TMP_Text uihighscore;
    int currentScore = 0;
    int highScore = 0;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
            Instance = this;

       
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //currentScore++;

        //uiScore.text = "Score: " + currentScore.ToString();
    }



    public void UpdateHighScore()
    {
        highScore = currentScore;
        uihighscore.text = "Highscore: " + highScore.ToString();
    }

    public void AddPoint(int point)
    {
        currentScore += point;
        uiScore.text = "Score: " + currentScore.ToString();
    }
}

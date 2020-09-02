using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    GameObject Text, ChangeScene;
    int UserScore { get; set;}
    int MaxScore { get; set; }


    public Score(GameObject scoreText, GameObject changeScene, int max)
    {
        MaxScore = UserScore = max;
        Text = scoreText;
        ChangeScene = changeScene;
    }

    public void DecrementScore()
    {
        UserScore--;
    }

    public void WinnerText()
    {
        Text.SetActive(true);
        Text.GetComponent<UnityEngine.UI.Text>().text = $"Ты набрал: {UserScore} из {MaxScore}";
        ChangeScene.SetActive(true);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowHighScore : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI score;

    void Start()
    {
        if(highScore != null)
            highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
    }

}

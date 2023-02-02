using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{

    public TextMeshProUGUI score;
    public TextMeshProUGUI score2;
    public Slider sheepgedomBar;

    public Sheepgedom sheepgedom;
    public ScoreSystem scoreSystem;

    public Slider bossHealth;

    public Slider playerHealth;

    void Start() {
        sheepgedomBar.maxValue = sheepgedom.maxSheeps;
        bossHealth.maxValue = GodSheep.Instance.life;
        playerHealth.maxValue = Player.Instance.maxLife;
    }

    void Update()
    {
        sheepgedomBar.value = sheepgedom.cSheeps;
        bossHealth.value = GodSheep.Instance.life;
        playerHealth.value = Player.Instance.life;
        score.text = scoreSystem.score.ToString();
        score2.text = scoreSystem.score.ToString();

    }
}

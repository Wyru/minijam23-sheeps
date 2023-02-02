using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        Barn.OnStoreSheep += storeSheep;
    }

    public void storeSheep(Sheep sheep){
        score += sheep.score;
    }

    public void StoreScore(){
        PlayerPrefs.SetInt("score", score);
    }

}

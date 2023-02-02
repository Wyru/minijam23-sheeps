using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        Player.OnGameOver += GameOver;
    }

    public void GameOver(){
        gameOver = true;
        GetComponent<Animator>().SetTrigger("In");
        
    }

    public void restartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

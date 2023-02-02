using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject tutorial;

    public void pressStart(){
        tutorial.SetActive(true);
        StartCoroutine(StartGame());
    }
    
    IEnumerator StartGame(){
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Game");
    }
}

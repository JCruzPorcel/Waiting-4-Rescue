using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskHide : MonoBehaviour
{
    public GameObject taskHide;

    public void TASKHIDE()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.task ||
        GameManager.sharedInstance.currentGameState == GameState.inGame ||
        GameManager.sharedInstance.currentGameState == GameState.menu)
        {
        GameManager.sharedInstance.currentGameState = GameState.inGame;
        taskHide.SetActive(false);
        }
    }

    public void ReanudeTimeScale(){
        Time.timeScale = 1f;
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayGame(){
        SceneManager.LoadScene("Game");
    }
    
    public void QuitGame(){
        Application.Quit();
    }

}

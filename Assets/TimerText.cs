using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    public GameObject PanelStatusGame;


    private void Update() {
        if(GameManager.sharedInstance.currentGameState == GameState.win || GameManager.sharedInstance.currentGameState == GameState.gameOver){
            StartCoroutine(TimerToMenu());
        }
    }

    IEnumerator TimerToMenu(){
        yield return new WaitForSeconds(2.5f);
        PanelStatusGame.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchO2Energy : MonoBehaviour
{

    public GameObject ErrorEnergyMss;
    public GameObject MessagePanel;
    public GameObject StatsPanel;
    public PlayerOxygen playerOxygen;


    void OnTriggerStay2D(Collider2D other)
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame 
        && GameManager.sharedInstance.currentGameState != GameState.gameOver)
        {
            if(other.tag == "Player" && Input.GetKey(KeyCode.E))
            {
                if(playerOxygen.EnergyOff == true){
                    ErrorEnergyMss.SetActive(true);
                    StatsPanel.SetActive(false);
                    GameManager.sharedInstance.currentGameState = GameState.task;
                } else if(!playerOxygen.EnergyOff){
                    StatsPanel.SetActive(true);
                    ErrorEnergyMss.SetActive(false);
                    GameManager.sharedInstance.currentGameState = GameState.task;
                }
            }

            MessagePanel.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
        ErrorEnergyMss.SetActive(false);
        StatsPanel.SetActive(false);
        MessagePanel.SetActive(false);
        }
    }

    
}

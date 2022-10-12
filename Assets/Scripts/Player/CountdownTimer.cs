using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime = 24f;
    public float DAYSPEED = 0.09f;
    public GameObject messageWeAreClose;
    public GameObject messageWaitForHelp;

    [SerializeField] Text countdownText;

    private void Start() {
        currentTime = startingTime;
        
    }

    private void Update() {
        if(GameManager.sharedInstance.currentGameState == GameState.task 
        || GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            currentTime -= DAYSPEED * Time.deltaTime;
            countdownText.text = currentTime.ToString ("0" + "h");

            if(currentTime <= 24){
                messageWaitForHelp.SetActive(true);
                messageWeAreClose.SetActive(false);
            }
            if (currentTime <= 12){
                messageWaitForHelp.SetActive(false);
                messageWeAreClose.SetActive(true);
            }



            if(currentTime <= 0)
            {
                GameManager.sharedInstance.WinGame();
                currentTime = 0;    
            }
        }
    }

}

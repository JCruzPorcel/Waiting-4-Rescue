using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOxygen : MonoBehaviour
{   

    [Header("ElectricTask")]
    
    [SerializeField]
    public bool EnergyOff = true;

    [SerializeField]
    public GameObject On;


    public GameObject Off;
    
    [Header("TaskCD")]

    [SerializeField]
    public float medikitHeal = 100f;

    [SerializeField]
    public float cooldownHeal;

    [SerializeField]
    private float nextHealTime = 0f;

    [SerializeField]
    public float AllTaskCD;

    [Header("Status Panic")]

    [SerializeField]
    public Slider alteredBar;

    [SerializeField]
    public float alteredAmount;

    [SerializeField]
    float currentAltered;
    
    public Image alteredWarning;
  
    [Header("Status Oxygen")]

    [SerializeField]
    public Slider oxygenBar;

    [SerializeField]
    public float oxygenAmount;

    [SerializeField]
    float currentOxygen; 

    public Image Target_Image;
    
    PlayerController controller;

    public void Start() {
        currentAltered = 0;
        currentOxygen = oxygenAmount;
        controller = GetComponent<PlayerController>();
    }

    
    public void Update() {

        if(GameManager.sharedInstance.currentGameState == GameState.task 
        || GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            OxygenDecreased();
            StateAlteredDecreased();
            


            if(currentAltered >= 75){

                alteredWarning.GetComponent<Image>().color = new Color32 (171, 43 ,57, 255);
                if(currentAltered >= alteredAmount){
                    currentOxygen -= 0.009f * 2;
                }
            }else if(currentAltered <= 75){
                alteredWarning.GetComponent<Image>().color = new Color32 (210, 107, 54, 255);
            }

            if(currentOxygen <= 25)
            {
                Target_Image.GetComponent<Image>().color = new Color32 (171, 43 ,57, 255);
                currentAltered = 0.009f * 2;
                if(currentOxygen <= 0)
                {
                    controller.PlayerDead();
                }
            }  
        }  
    }

    public void StateAlteredDecreased(){
        if(!EnergyOff)
        {
            currentAltered += 0.009f;
            alteredBar.value = currentAltered/alteredAmount;

        }else if(EnergyOff){
            currentAltered += 0.009f * 1.5f;
            alteredBar.value = currentAltered/alteredAmount;

        }
    }

    public void OxygenDecreased(){
        currentOxygen -= 0.009f;
        oxygenBar.value = currentOxygen/oxygenAmount;
    }

   public void BoostedKit()
   {    
       if(GameManager.sharedInstance.currentGameState == GameState.task 
        || GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if(Time.time > nextHealTime)
            {          
                
                currentAltered -= medikitHeal;
                nextHealTime = Time.time + cooldownHeal;
                Debug.LogWarning("HEAL+");

                if (currentAltered <= -0.1f){
                currentAltered = 0f;
                Debug.Log("0");
                
                }
            }
        }
    }


    public void ElectricsTask(){
        if(GameManager.sharedInstance.currentGameState == GameState.task 
        || GameManager.sharedInstance.currentGameState == GameState.inGame)
        {       

            if( EnergyOff == true){
                On.SetActive(true);
                Off.SetActive(false);
                EnergyOff = false;
                StartCoroutine(TaskWaiting());
            }
        }
    }
    
    IEnumerator TaskWaiting(){
    yield return new WaitForSeconds(Mathf.Lerp(35f , 60f , Random.value));
    EnergyOff = true;
    Off.SetActive(true);
    On.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    intro,
    task,
    menu,
    inGame,
    gameOver,
    win
}

public class GameManager : MonoBehaviour
{   
    //Panels
    public GameObject WinPanel;
    public GameObject LosePanel;

    public GameState currentGameState = GameState.intro;

    public static GameManager sharedInstance;

    private PlayerController controller;

    void Awake()
    {
        if(sharedInstance == null){
            sharedInstance = this;
        }

        StartCoroutine (WaitSys ());
    }

    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();

        }

    void Update()
    {
        var Menu = Input.GetAxisRaw("Cancel");
    }

    IEnumerator WaitSys(){
        yield return new WaitForSeconds(5f);
        currentGameState = GameState.inGame;
    }

    public void StartGame(){
        SetGameState(GameState.inGame);

    }

    public void GameOver(){
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu(){
        SetGameState(GameState.menu);
    }

    public void WinGame(){
        SetGameState(GameState.win);
    }


    private void SetGameState(GameState newGameState){
        if(newGameState == GameState.menu){
            
            //TODO: Logica del menu
           
        }else if(newGameState == GameState.inGame)
        {
            
            //TODO: hay que preparar la escena para jugar

        } else if(newGameState == GameState.gameOver){

            LosePanel.SetActive(true);
            //TODO: preparar el juego para Game Over.

        }else if (newGameState == GameState.win){
            WinPanel.SetActive(true);

            //TODO: MENU WIN
        }else if(newGameState == GameState.intro){

        
            //TODO: MENU INTRO

        }

        this.currentGameState = newGameState;
    }
}
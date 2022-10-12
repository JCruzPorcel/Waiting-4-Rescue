using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Panelmenu;
    public float climbSpeed;
    Rigidbody2D rb;
    //Player Controller
    public float MovementSpeed;
    Animator animator;
    //public float JumpForce;
    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update() {

         if(GameManager.sharedInstance.currentGameState == GameState.inGame){

            if(Input.GetKey(KeyCode.Escape) && GameManager.sharedInstance.currentGameState != GameState.menu){
               
                GameManager.sharedInstance.currentGameState = GameState.menu;
                Panelmenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        
    }
    private void FixedUpdate() 
    {
        

        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {

            var movement = Input.GetAxis("Horizontal");

            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

                
            if(!Mathf.Approximately(0, movement))

                transform.rotation = movement <  0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
                animator.SetFloat ("Speed", Mathf.Abs(movement));

           /* if(Input.GetButtonDown("Jump") && Mathf.Abs (rb.velocity.y) < 0.001f){
                
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }*/
        }
    }
    public void PlayerDead(){
        GameManager.sharedInstance.GameOver();
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if(GameManager.sharedInstance.currentGameState == GameState.inGame){
           
           if (other.tag == "LadderExit"){
               animator.SetBool("LadderUp", false);
               animator.SetBool("StaticLadder", false);
           }
            if(other.tag == "Ladder" && Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2 (0, climbSpeed);
               
                animator.SetBool("LadderUp", true);
                animator.SetBool("StaticLadder", false);

            }
            else if(other.tag == "Ladder" && Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2 (0, -climbSpeed);

                animator.SetBool("LadderUp", true);
                animator.SetBool("StaticLadder", false);
                
            }else {
                if(other.tag == "Ladder"){
                    rb.velocity = new Vector2 (0, 0);
                    animator.SetBool("StaticLadder", true); // LadderUp false
                }       
            }
        }
    }
}

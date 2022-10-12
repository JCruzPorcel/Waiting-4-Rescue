using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    public float climbSpeed;
    
    void OnTriggerStay2D(Collider2D other)
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame){

        if(other.tag == "Player" && Input.GetKey(KeyCode.W))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, climbSpeed);

        }
        else if(other.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, -climbSpeed);

        }else {
            other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
         }
    
        }
    }
}
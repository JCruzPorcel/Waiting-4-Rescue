using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;


    public Vector3 offset = new Vector3(0.2f, 0.0f, -10f);

    public float dampingTime = 0.3f;

    public Vector3 velocity = Vector3.zero;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void FixedUpdate()
    {
        MoveCamera(true);
    }

    public void ResetCameraPosition(){
        MoveCamera(false);
    }

    void MoveCamera(bool smooth){
        Vector3 destination = new Vector3(PlayerTransform.position.x - offset.x, PlayerTransform.position.y - offset.y, offset.z);

        if(smooth){
            this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref velocity,dampingTime);
        }else{
            this.transform.position = destination;
        }
    }
}

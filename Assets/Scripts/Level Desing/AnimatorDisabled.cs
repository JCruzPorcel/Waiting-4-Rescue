using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorDisabled : MonoBehaviour
{
    public Animator myanim;
    public CameraFollow cameraFollow;

    private void Awake() {
        StartCoroutine (WaitSys ());

    }

    IEnumerator WaitSys(){
        yield return new WaitForSeconds(5f);
        AnimatorDisable();
    }

    public void AnimatorDisable(){
        myanim.enabled = false;
        cameraFollow.enabled = true;
    }
}

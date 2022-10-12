using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
   AudioSource audioSource;

    private void Awake() {
       StartCoroutine(StartSong());
   }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

   IEnumerator StartSong(){
       yield return new WaitForSeconds(5.1f);
       audioSource.Play();
   }
}

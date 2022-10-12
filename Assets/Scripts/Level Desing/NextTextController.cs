using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTextController : MonoBehaviour
{
    public GameObject Texto1;
    public GameObject Texto2;


   private void Awake() {
       StartCoroutine(Text1Timer());
   }

    IEnumerator Text1Timer(){
        yield return new WaitForSeconds(8f);
        
        Texto1.SetActive(true);
        Texto2.SetActive(false);
        StartCoroutine(Text2Timer());

    }

    IEnumerator Text2Timer(){
        yield return new WaitForSeconds(8f);

        Texto1.SetActive(false);
        Texto2.SetActive(true);
        StartCoroutine(Text1Timer());
    }
}

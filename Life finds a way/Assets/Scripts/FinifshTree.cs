using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinifshTree : MonoBehaviour
{   
    [SerializeField] GameObject Flowers; 
    
    SceneLoader loadNext;
    void Start() {
        Flowers.gameObject.SetActive (false);
        loadNext = FindObjectOfType<SceneLoader>();
    }
    
    IEnumerator Delay(){
        // Flowers.gameObject.transform.localScale = new Vector3 (0f,0f,1f);
        Flowers.gameObject.SetActive (true);
        // for (float i = 0; i < 1f ; i += 0.2f){
        //     Vector3 upscale = new Vector3 (i,i,0f);
        //     Flowers.gameObject.transform.localScale += upscale;
        //     yield return new WaitForSeconds(1);
        // }
        yield return new WaitForSeconds(3);
        loadNext.LoadNextScene();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            StartCoroutine(Delay());
        }
    }
}

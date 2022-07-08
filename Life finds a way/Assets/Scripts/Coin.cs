using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{   
    [SerializeField] GameObject coinPlaceholder;
    public int listNumber;
    private Image placeholderClone;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            if(coinPlaceholder.transform.childCount > 0){
            placeholderClone = coinPlaceholder.transform.GetChild(listNumber).GetComponent<Image>();
            placeholderClone.enabled = false;
            FindObjectOfType<GameSession>().AddToScore();
            }
            Destroy(gameObject);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinGeneratorUI : MonoBehaviour{  

    [SerializeField] Image goldCoin;
    [SerializeField] Image silverCoin;
    public List<GameObject> CoinsLevel = new List<GameObject>();
    Coin script;
    
    
    void Start(){
        
        for(int i = 0 ; i < CoinsLevel.Count ; i++){
            if(CoinsLevel[i].gameObject.tag == "Gold"){
                Image Golden = Object.Instantiate (goldCoin, this.transform) as Image; 
            }
            if(CoinsLevel[i].gameObject.tag == "Silver"){
                Image Silver = Object.Instantiate (silverCoin, this.transform) as Image;
            }
            script = CoinsLevel[i].gameObject.GetComponent<Coin>();
            script.listNumber = i;
        }
    }

}

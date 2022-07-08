using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceholderGeneratorUI : MonoBehaviour{   

    [SerializeField] Image grayCircle;
    CoinGeneratorUI coins;
    [SerializeField] GameObject Generator;

    
    // Start is called before the first frame update
    private void Start(){
        coins = Generator.GetComponent<CoinGeneratorUI>();
        foreach(GameObject coinCount in coins.CoinsLevel){
            Image Placeholder = Instantiate (grayCircle, this.transform) as Image;
        }
    }
}

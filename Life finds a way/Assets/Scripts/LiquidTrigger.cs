using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LiquidTrigger : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    SoundEffectManager parentScript;
    private GameObject player;
    private GodTierSwapping swapping;

    void Start() 
    {
        player = GameObject.Find("Player");
        swapping = player.GetComponent<GodTierSwapping>();
        parentScript = this.transform.parent.GetComponent<SoundEffectManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Lava")
        {
            parentScript.lavasplash();
            swapping.state = 2;
        }
        if (collision.gameObject.tag == "Electric")
        {
            parentScript.electricshock();
            gameOverCanvas.SetActive(true);
        }
        if (collision.gameObject.tag == "Water")
        {
            parentScript.watersplash();
        }
        if (collision.gameObject.tag == "Gold")
        {
            parentScript.goldcollect();
        }
        if (collision.gameObject.tag == "Silver")
        {
            parentScript.silvercollect();
        }
        if (collision.gameObject.tag == "Acid")
        {
            parentScript.acidsplash();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ice")
        {
            swapping.state = 1;
        }
        if (other.gameObject.tag == "Sand")
        {
            gameOverCanvas.SetActive(true);
        }
    }
}
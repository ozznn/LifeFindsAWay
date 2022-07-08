using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolidTrigger : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    SoundEffectManager parentScript;
    void Start()
    {
        parentScript = this.transform.parent.GetComponent<SoundEffectManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = GameObject.Find("Player");
        GodTierSwapping swapping = player.GetComponent<GodTierSwapping>();
        if (collision.gameObject.tag == "Lava")
        {
            parentScript.lavasplash();
            gameOverCanvas.SetActive(true);
        }
        if (collision.gameObject.tag == "Fire")
        {
            parentScript.fireburn();
            swapping.state = 3;
        }
        if (collision.gameObject.tag == "Acid")
        {
            parentScript.acidsplash();
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
        if (collision.gameObject.tag == "Grass")
        {
            parentScript.grassrustling();
        }
        if (collision.gameObject.tag == "Gold")
        {
            parentScript.goldcollect();
        }
        if (collision.gameObject.tag == "Silver")
        {
            parentScript.silvercollect();
        }
    }
}

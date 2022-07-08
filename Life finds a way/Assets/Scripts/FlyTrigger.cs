using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyTrigger : MonoBehaviour
{   
    SoundEffectManager parentScript;
    [SerializeField] GameObject gameOverCanvas;
    private GameObject player;
    private GodTierSwapping swapping;
    bool collided = false;

    void Start() 
    {
        player = GameObject.Find("Player");
        swapping = player.GetComponent<GodTierSwapping>();
        parentScript = this.transform.parent.GetComponent<SoundEffectManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Grass")
        {
            parentScript.grassrustling();
            swapping.state = 3;
        }
        if (collision.gameObject.tag == "Fire")
        {
            //effect option.
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
   
    IEnumerator OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.tag == "Platform"){
            collided = true;
            yield return new WaitForSeconds(0.01f);
            if (collided)
            {
                collided = false;
                gameOverCanvas.SetActive(true);
            }
        }
        if(collider.gameObject.tag == "Ice"){
            swapping.state = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
    }
}

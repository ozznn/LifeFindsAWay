using UnityEngine;
using System.Collections.Generic;

// Starting in 0 seconds.
// a function will be run every 0.5 seconds

public class InvokeRepeatCloud : MonoBehaviour
{
    public int AniCount = 0;
    public SpriteRenderer spriteRenderer;
    public Sprite Sprite1, Sprite2, Sprite3;

    void Start()
    {
        InvokeRepeating("frameAnimation", 0.0f, 0.3f);
    }

    void frameAnimation()
    {
        if(AniCount == 0){
            spriteRenderer.sprite = Sprite1; 
            AniCount = 1;
        } else if(AniCount == 1){
            spriteRenderer.sprite = Sprite2; 
            AniCount = 2;
        } else if(AniCount == 2){
            spriteRenderer.sprite = Sprite3; 
            AniCount = 3;
        } else {
            spriteRenderer.sprite = Sprite2; 
            AniCount = 0;
        }

    }
}
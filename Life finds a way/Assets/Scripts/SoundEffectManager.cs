using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    private Rigidbody2D rb;
    public AudioClip grassRustling;
    public AudioClip waterSplash;
    public AudioClip fireBurn;
    public AudioClip lavaSplash;
    public AudioClip acidSplash;
    public AudioClip electricShock;
    public AudioClip silverCollect;
    public AudioClip goldCollect;
   
    public void grassrustling()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(grassRustling, 0.4F);
    }
    public void watersplash()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(waterSplash);
    }
    public void fireburn()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(fireBurn, 0.6F);
    }
    public void lavasplash()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(lavaSplash, 1.0F);
    }
    public void acidsplash()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(acidSplash, 0.8F);
    }
    public void electricshock()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(electricShock, 0.3F);
    }
    public void silvercollect()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(silverCollect, 0.6F);
    }
    public void goldcollect()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(goldCollect, 0.4F);
    }

}

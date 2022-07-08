using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject musicVolume;
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        musicVolume = GameObject.Find("Music Player");
    }

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        FindObjectOfType<GameSession>().SaveResetScore();
    }

    public void ReloadScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        FindObjectOfType<GameSession>().ResetScore();
    }

    public void LoadStartScene() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void PauseGame() {
        Time.timeScale = 0;
        LowerVolume();
    }
    public void UnPauseGame() {
        Time.timeScale = 1;
        RaiseVolume();
    }

    public void ExitPauseMenu() {
        pauseMenu.SetActive(false);
    }

    public void VolumeControl() {
        musicVolume.GetComponent<AudioSource>().volume = volumeSlider.value;
    }

    public void RaiseVolume() {
        musicVolume.GetComponent<AudioSource>().volume *= 4.0f;
    }
    public void LowerVolume() {
        musicVolume.GetComponent<AudioSource>().volume *= 0.25f;
    }
}
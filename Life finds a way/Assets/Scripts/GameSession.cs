using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    public int currentScore = 1;
    public int totalScore = 0;

    // Start is called before the first frame update


    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddToScore() {
        currentScore += 1;
    }

    public void ResetScore() {
        currentScore = 0;
    }

    public void SaveResetScore() {
        totalScore += currentScore;
        currentScore = 0;
    }
}


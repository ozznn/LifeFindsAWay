using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedalPicker : MonoBehaviour
{
    public GameObject Gold;
    [SerializeField] GameObject Silver;
    [SerializeField] GameObject Bronze;
    [SerializeField] GameObject None;
    void Start()
    {
        if (FindObjectOfType<GameSession>().currentScore == 0) {
            None.SetActive(true);
        } else if (FindObjectOfType<GameSession>().currentScore == 1) {
            Bronze.SetActive(true);
        } else if (FindObjectOfType<GameSession>().currentScore == 2) {
            Silver.SetActive(true);
        } else {
            Gold.SetActive(true);
        }
    }

}

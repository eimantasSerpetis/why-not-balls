using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    
    public static int scoreValue = 0;
    static Text score;

    void Start() {
        score = GetComponent<Text>();
    }

    void Update() {
        score.text = "Score: " + scoreValue;
    }
    public static void restartScore()
    {
        scoreValue = 0;
    }
    public static void Disable()
    {
        score.enabled = false;
    }
}
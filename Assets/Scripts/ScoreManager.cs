using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//A score manager module
public class ScoreManager : MonoBehaviour {
    //Creating variables to manage scoring
    public Text scoreText;
    public Text highScoreText;
    public float score;
    public float highScore;
    public float scorePerSecond;
    public bool allowScoring;
    private PlayerPrefs PlayerPrefs;


	// Use this for initialization
	void Start () {
        //Checking to see if there is a highScore currently stored, if so get it. If not, default to 0
	    if (PlayerPrefs.HasKey("highScore")) {
            highScore = PlayerPrefs.GetFloat("highScore");
        } else {
            highScore = 0;
        }

        //Score always defaults to 0 and allowScoring always is true on start
        score = 0;
        allowScoring = true;
	}
	
	// Update is called once per frame
	void Update () {
        //If allowScoring is true
	    if (allowScoring) {
            //Updating the score based on the amount of time passed
            score += scorePerSecond * Time.deltaTime;

            //If the score has surpassed the highScore, then update the highScore to the score
            if(score > highScore) {
                highScore = score;
            }

            //Updating score texts on screen and rounding them to remove decimals
            scoreText.text = "Score: " + Mathf.Round(score);
            highScoreText.text = "High Score: " + Mathf.Round(highScore);
        }
	}

    //A function to save the score
    public void saveScore() {
        PlayerPrefs.SetFloat("highScore", highScore);
        PlayerPrefs.Save();
    }
    
    //A function to disable scoring once dead to stop the score from incrementing
    public void setScoringFalse() {
        allowScoring = false;
    }

}

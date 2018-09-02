using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour {

    //Public Variables
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI scoreText;
    public float earnRate; //How fast we earn just by moving through space and time
    public int score; //our current score duhhh
    public int highScore; //our highest score SO FAR!
    public bool gameOver; //is our game lost at all?

    private float timer;


	// Use this for initialization
	void Start () {
        highScore = PlayerPrefs.GetInt("HighScore",highScore);
        highscoreText.text = "Highscore : " + highScore.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        if(!gameOver)
        {
            scoreText.text = "Score : " + score.ToString();
            highscoreText.text = "Highscore : " + highScore.ToString();

            if(score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", score);
            }

            //Increment our timer then add to our score 1 point based on earn rate
            timer += Time.deltaTime;

            if (timer > earnRate)
            {
                //As a fatty whale it's a miracle you made it this far. You win 1 point try not to eat it.
                EarnScore(1);
            }
        }
	}


    //Basic Method to earn a scoring point
    public void EarnScore(int earnedPoints)
    {
        score += earnedPoints;

        timer = 0.0f;
    }

    
}

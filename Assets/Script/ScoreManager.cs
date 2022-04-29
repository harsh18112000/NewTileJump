using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int highScore;
    public Text scoretext;
    public Text LastScore;
    public Text hightext;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        hightext.text = highScore.ToString();
    }

    public void ScoreIncrease()
    {
        score++;
        scoretext.text = score.ToString();
        LastScore.text = score.ToString();
    }

    public void ScoreReset()
    {
        score = 0;
        scoretext.text = score.ToString();
    }

    public void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
            hightext.text = highScore.ToString();
        }

        ScoreReset();
    }

}

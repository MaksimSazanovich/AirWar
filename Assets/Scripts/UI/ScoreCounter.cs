using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text endScoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private LevelManager levelManager;
    private int score;
    private int highScore;
    private float timeBeetweenAddingScore;
    private int thresold = 100;
    private int scoreCoefficient=9;

    public UnityEvent OnThresholdPassed;
    public UnityEvent NewRecord;
    public UnityEvent DefaultRecord;
    private void Start()
    {
        SetStartTime();
        highScore = PlayerPrefs.GetInt("highScore");
    }


    void FixedUpdate()
    {
        if (Time.timeScale > 0 && levelManager.ReturnSceneIndex()==1)
        {
            score++;
            scoreText.text = "" + score / scoreCoefficient;
            timeBeetweenAddingScore += 0.2f;
            if (score/ scoreCoefficient >= thresold)
            {
                OnThresholdPassed.Invoke();
                thresold += 100;
            }
        }

    }

    public void SetStartTime()
    {
        timeBeetweenAddingScore = 0.2f;
    }

    public void AddScore(int enemyScore)
    {
        score += enemyScore;
        scoreText.text = "" + score / scoreCoefficient;
    }

    public void ShowEndScore()
    {
        endScoreText.text = "" + score / scoreCoefficient;
        if (highScore <= score / scoreCoefficient)
        {
            highScore = score / scoreCoefficient;
            NewRecord.Invoke();
            PlayerPrefs.SetInt("highScore", highScore);

        }
        else DefaultRecord.Invoke();


    }

}

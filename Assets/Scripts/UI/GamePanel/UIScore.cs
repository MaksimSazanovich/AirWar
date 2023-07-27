using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private ScoreCollector scoreCollector;

    private void OnEnable()
    {
        scoreCollector.OnScoreChanged += ShowValue;
    }

    private void OnDisable()
    {
        scoreCollector.OnScoreChanged -= ShowValue;
    }
    public void ShowValue(int value)
    { 
        scoreText.text = value.ToString();
    }
}
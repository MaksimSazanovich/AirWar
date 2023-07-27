using System;
using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
	[SerializeField] internal event Action<int> OnScoreChanged;
	public static int scoreCollected;

	private void Awake()
	{
		scoreCollected = 0;
        OnScoreChanged?.Invoke(scoreCollected);
    }
	private void OnEnable()
	{
		ObjectScore.OnChanged += ObjectScore_OnChanged;
	}
	private void OnDisable()
	{
		ObjectScore.OnChanged -= ObjectScore_OnChanged;
    }

	private void ObjectScore_OnChanged(int value)
	{
		scoreCollected += value;
		OnScoreChanged.Invoke(scoreCollected);
	}
}
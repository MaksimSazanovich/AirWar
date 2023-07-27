using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePanel : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private LosePanel losePanel;

    [Inject]
    private void Construct(PlayerHealth playerHealth, LosePanel losePanel)
    {
        this.playerHealth = playerHealth;
        this.losePanel = losePanel;
    }

    private void OnEnable()
    {
        playerHealth.OnDie += ShowLosePanel;
    }

    private void OnDisable()
    {
        playerHealth.OnDie -= ShowLosePanel;
    }

    private void ShowLosePanel()
    {
        losePanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    } 
}
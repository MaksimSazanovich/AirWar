using TMPro;
using UnityEngine;
using Zenject;

public class HealthText : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;

    private PlayerHealth _playerHealth;

    [Inject]
    private void Construct(PlayerHealth playerHealth)
    {
        this._playerHealth = playerHealth;
    }

    private void OnEnable()
    {
        _playerHealth.OnHealthChanged += ShowHealth;
    }

    private void Start()
    {
        ShowHealth(_playerHealth.MaxHealth);
    }

    private void OnDisable()
    {
        _playerHealth.OnHealthChanged -= ShowHealth;
    }
    public void ShowHealth(int health)
    {
        _healthText.text = "" + health;
    }
}

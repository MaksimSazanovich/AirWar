using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerTypeSwitchButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    private PlayerTypeSwitch _playerTypeSwitch;
    private bool canPress = false;
    private float totalTime = 6;
    private Color translucent = new Color(1, 1, 1, 0.5f);

    [Inject]
    private void Construct(PlayerTypeSwitch playerTypeSwitch)
    {
        _playerTypeSwitch = playerTypeSwitch;
    }
    private void Start()
    {
        _button.onClick.AddListener(SwitchPlayerType);
        _playerTypeSwitch.OnEvasionEnded += StartTimer;
        StartTimer();
    }

    private void SwitchPlayerType()
    {
        _playerTypeSwitch.SwitchToMini();
        _image.gameObject.SetActive(false);
    }

    private void StartTimer()
    {
        _image.gameObject.SetActive(true);
        _button.enabled = false;
        _image.color = translucent;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        float currentTime = 0;
        while (currentTime < totalTime)
        {
            _image.fillAmount = currentTime / totalTime;
            currentTime += Time.deltaTime;
            yield return null;
        }
        _image.fillAmount = 1;
        ShowButton();
    }

    private void ShowButton()
    {
        _button.enabled = true;
        _image.color = Color.white;
    }
}
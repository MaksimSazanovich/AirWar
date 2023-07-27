using System;
using System.Collections;
using UnityEngine;

public class PlayerTypeSwitch : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _collider;
    private PlayerAnimator _animator;

    [SerializeField] private float evasiontime = 2f;

    [SerializeField] private Sprite[] _sprites;
    private Vector2[] _colliderOffsets = { new Vector2(0, 0.03167987f), new Vector2(0, 0.002481043f) };
    private Vector2[] _colliderSizes = { new Vector2(1, 1.31463f), new Vector2(0.73f, 0.6416024f) };

    public event Action OnEvasionEnded;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<PlayerAnimator>();
    }

    public void SwithTypeTo(PlayerType type)
    {
        _collider.offset = _colliderOffsets[(int)type];
        _collider.size = _colliderSizes[(int)type];
        _spriteRenderer.sprite = _sprites[(int)type];
    }

    public void SwitchToMini()
    {
        _animator.StopFlyAnimation();
        SwithTypeTo(PlayerType.Mini);
        StartCoroutine(Evasion());
    }
    public void SwitchToDefault()
    {
        _animator.PlayFlyAnimation();
        SwithTypeTo(PlayerType.Default);
        OnEvasionEnded?.Invoke();
    }

    private IEnumerator Evasion()
    {
        yield return new WaitForSeconds(evasiontime);
        SwitchToDefault();
    }
}

public enum PlayerType
{
    Default,
    Mini
}
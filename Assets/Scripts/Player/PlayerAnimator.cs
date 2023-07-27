using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("canFly", true);
    }

    public void StopFlyAnimation()
    { 
        _animator.StopPlayback();
        _animator.SetBool("canFly", false);
        _animator.enabled = false;
    }

    public void PlayFlyAnimation()
    {
        _animator.enabled = true;
        _animator.SetBool("canFly", true);
    }
}
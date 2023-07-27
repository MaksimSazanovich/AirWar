using UnityEngine;

public abstract class ObjectAnimator : MonoBehaviour
{
    protected Animator _animator;

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();    
    }
}
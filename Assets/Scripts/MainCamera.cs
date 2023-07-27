using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Shake()
    {
        animator.SetTrigger("Shake");
    }
}

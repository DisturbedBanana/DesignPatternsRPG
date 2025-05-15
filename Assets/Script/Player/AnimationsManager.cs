using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Reset()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void StartIdleAnim()
    {
        animator.SetTrigger("IdleTrigger");
    }
}

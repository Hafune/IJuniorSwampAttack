using UnityEngine;

public class CelebrationState : State
{
    [SerializeField] private Animator _animator;

    private void OnEnable() => _animator.Play("Celebration");

    private void OnDisable() => _animator.StopPlayback();
}
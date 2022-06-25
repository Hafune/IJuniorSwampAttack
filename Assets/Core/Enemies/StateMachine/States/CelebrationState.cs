using UnityEngine;
using UnityEngine.Assertions;

public class CelebrationState : State
{
    [SerializeField] private Animator _animator;

    private void Awake() => Assert.IsNotNull(_animator);

    private void OnEnable() => _animator.Play("Celebration");

    private void OnDisable() => _animator.StopPlayback();
}
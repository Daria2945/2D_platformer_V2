using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationSwicher : MonoBehaviour
{
    public readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
    public readonly int IsHurt = Animator.StringToHash(nameof(IsHurt));
    public readonly int IsDead = Animator.StringToHash(nameof(IsDead));
    public readonly int IsLive = Animator.StringToHash(nameof(IsLive));

    protected Animator Animator { get; private set; }

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        StartLive();
    }

    public void StartLive() =>
        Animator.SetBool(IsLive, true);

    public void StopLive() =>
        Animator.SetBool(IsLive, false);

    public void Attack() =>
        Animator.SetTrigger(IsAttack);

    public void TakeDamage() =>
        Animator.SetTrigger(IsHurt);

    public void Die() =>
        Animator.SetTrigger(IsDead);
}
using UnityEngine;

public class EnemyAnimationSwicher : AnimationSwicher
{
    public readonly int IsIdle = Animator.StringToHash(nameof(IsIdle));
    public readonly int IsWalk = Animator.StringToHash(nameof(IsWalk));
    public readonly int IsRun = Animator.StringToHash(nameof(IsRun));

    public void SetAnimation(bool isIdle, bool isWalk, bool isRun)
    {
        Animator.SetBool(IsIdle, isIdle);
        Animator.SetBool(IsWalk, isWalk);
        Animator.SetBool(IsRun, isRun);
    }
}
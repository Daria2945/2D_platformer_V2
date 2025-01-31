using UnityEngine;

public class PlayerAnimationSwicher : AnimationSwicher
{
    public readonly int VelocityX = Animator.StringToHash(nameof(VelocityX));
    public readonly int VelocityY = Animator.StringToHash(nameof(VelocityY));
    public readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
    
    public void SetAnimation(float velocityX, float velocityY, bool isGrounded)
    {
        Animator.SetFloat(VelocityX, velocityX);
        Animator.SetFloat(VelocityY, velocityY);
        Animator.SetBool(IsGrounded, isGrounded);
    }
}
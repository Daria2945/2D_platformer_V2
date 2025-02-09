using UnityEngine;

[RequireComponent(typeof(PlayerMoverInfo))]
public class PlayerMover : MonoBehaviour
{
    private PlayerMoverInfo _info;
    private PlayerStateMachine _stateMachine;

    private void Awake()
    {
        _info = GetComponent<PlayerMoverInfo>();
    }

    private void Start()
    {
        _stateMachine = new PlayerStateMachine(_info);
    }

    private void Update()
    {
        PlayAnimation();

        _stateMachine?.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine?.FixedUpdate();
    }

    private void PlayAnimation()
    {
        float velocityX = Mathf.Abs(_info.Player.Rigidbody.velocity.x);
        float velocityY = _info.Player.Rigidbody.velocity.y;
        bool isGround = _info.GroundDetector.IsGrounded;

        ((PlayerAnimationSwicher)_info.Player.AnimationSwicher).SetAnimation(velocityX, velocityY, isGround);
    }
}
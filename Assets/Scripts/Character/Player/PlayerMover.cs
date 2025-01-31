using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMoverInfo))]
public class PlayerMover : MonoBehaviour
{
    private PlayerMoverInfo _info;

    private ListPlayerStates _states;
    private PlayerState _currentState;

    private void Awake()
    {
        _info = GetComponent<PlayerMoverInfo>();
    }

    private void Start()
    {
        _states = new ListPlayerStates(_info);
    }

    private void Update()
    {
        ChangeState();

        _currentState?.Update();
    }

    private void FixedUpdate()
    {
        _currentState?.FixedUpdate();
    }

    private void ChangeState()
    {
        float direction = _info.InputReader.Direction;
        float velocityY = _info.Player.Rigidbody.velocity.y;
        float velocityX = _info.Player.Rigidbody.velocity.x;
        bool canJump = _info.InputReader.CanJump();
        bool isGround = _info.GroundDetector.IsGrounded;

        PlayAnimation(MathF.Abs(velocityX), velocityY, isGround);

        _currentState = _states.GetState(direction, velocityY, canJump, isGround);
        SetNewState(_currentState);
    }

    private void SetNewState(PlayerState state)
    {
        _currentState = state;
        _currentState?.Enter();
    }

    private void PlayAnimation(float speed, float velocityY, bool isGround)
    {
        ((PlayerAnimationSwicher)_info.Player.AnimationSwicher).SetAnimation(speed, velocityY, isGround);
    }
}
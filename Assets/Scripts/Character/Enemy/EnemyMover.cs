using UnityEngine;

[RequireComponent(typeof(EnemyMoverInfo))]
public class EnemyMover : MonoBehaviour
{
    private EnemyMoverInfo _info;
    private EnemyStateMachine _stateMachine;

    private bool _isPatrol => _stateMachine.CurrentState.GetType() == typeof(EnemyPatrol);

    private void Awake()
    {
        _info = GetComponent<EnemyMoverInfo>();
    }

    private void Start()
    {
        _stateMachine = new EnemyStateMachine(_info);
    }

    private void Update()
    {
        PlayAnimation();

        _stateMachine?.Update();
    }

    private void FixedUpdate()
    {
        if (_info.GroundDetector.IsGrounded)
            _stateMachine?.FixedUpdate();
    }

    private void PlayAnimation()
    {
        bool isIdle = _info.Enemy.Rigidbody.velocity.x == 0;
        bool isWalk = _isPatrol && isIdle == false;
        bool isRun = _isPatrol == false && isIdle == false;

        ((EnemyAnimationSwicher)_info.Enemy.AnimationSwicher).SetAnimation(isIdle, isWalk, isRun);
    }
}
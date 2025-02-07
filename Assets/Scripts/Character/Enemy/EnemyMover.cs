using UnityEngine;

[RequireComponent(typeof(EnemyMoverInfo))]
public class EnemyMover : MonoBehaviour
{
    private EnemyMoverInfo _info;
    private ListEnemyState _states;

    private EnemyState _currentState;

    private bool _isPatrol;

    private void Awake()
    {
        _info = GetComponent<EnemyMoverInfo>();
    }

    private void Start()
    {
        _states = new ListEnemyState(_info);
    }

    private void Update()
    {
        PlayAnimation();
        ChangeStates();

        _currentState?.Update();
    }

    private void FixedUpdate()
    {
        if (_info.GroundDetector.IsGrounded)
            _currentState?.FixedUpdate();
    }

    private void ChangeStates()
    {
        if (_info.Target != null)
        {
            _isPatrol = false;

            if (Vector2.Distance(transform.position, _info.Target.transform.position) <= _info.AttackDistance)
                _states.StartAttack(out _currentState);
            else
                _states.StartChest(_info.Target, out _currentState);
        }
        else if (_info.Target == null && _isPatrol == false)
        {
            _isPatrol = true;
            _states.StartPatrol(out _currentState);
        }
    }

    private void PlayAnimation()
    {
        bool isIdle = _info.Enemy.Rigidbody.velocity.x == 0;
        bool isWalk = _isPatrol && isIdle == false;
        bool isRun = _isPatrol == false && isIdle == false;

        ((EnemyAnimationSwicher)_info.Enemy.AnimationSwicher).SetAnimation(isIdle, isWalk, isRun);
    }
}
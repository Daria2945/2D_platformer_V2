using UnityEngine;

public class EnemyWalk : EnemyState
{
    private Transform _target;
    private Transform _transform;

    private Vector2 _direction => (_target.position - _transform.position).normalized;

    public EnemyWalk(StateMachine stateMachine, EnemyMoverInfo enemyMoverInfo) : base(stateMachine, enemyMoverInfo)
    {
        _transform = enemyMoverInfo.transform;
    }

    public void SetTarget(Transform target) =>
        _target = target;

    public override void FixedUpdate() =>
        ChangerSpeed.ChangeVelocityX(_direction.x, Info.SpeedMove);
}
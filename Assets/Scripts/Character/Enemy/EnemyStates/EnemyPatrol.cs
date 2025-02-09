using UnityEngine;

public class EnemyPatrol : EnemyState
{
    private EnemyWalk _walk;

    private Transform _transform;
    private int _currentPoint;

    private bool _isTargetReached => Vector2.Distance(_transform.position, Info.Waypoints[_currentPoint].position) <= Info.RequiredProximityToTargetPoint;

    public EnemyPatrol(StateMachine stateMachine, EnemyMoverInfo enemyMoverInfo) : base(stateMachine, enemyMoverInfo)
    {
        _transform = enemyMoverInfo.transform;
        InitializeWalk();
    }

    public override void Enter()
    {
        _currentPoint = 0;
        SetTarget();
    }

    public override void Update()
    {
        if (_isTargetReached)
            ChangeCurrentPoint();

        if (Info.Target != null)
            StateMachine.SetSate<EnemyChest>();
    }

    public override void FixedUpdate()
    {
        _walk?.FixedUpdate();
    }

    private void InitializeWalk()
    {
        _walk = new EnemyWalk(StateMachine, Info);
        _walk.Inizialize();

        _walk.SetTarget(Info.Waypoints[_currentPoint]);
    }

    private void SetTarget()
    {
        _walk.SetTarget(Info.Waypoints[_currentPoint]);
    }

    private void ChangeCurrentPoint()
    {
        _currentPoint = ++_currentPoint % Info.Waypoints.Length;

        _walk.SetTarget(Info.Waypoints[_currentPoint]);
    }
}
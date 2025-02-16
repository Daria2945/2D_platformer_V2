using UnityEngine;

public class EnemyChest : EnemyState
{
    private EnemyWalk _walk;

    public EnemyChest(StateMachine stateMahine, EnemyMoverInfo enemyMoverInfo) : base(stateMahine, enemyMoverInfo)
    {
        InitializeWalk();
    }

    private void InitializeWalk()
    {
        _walk = new EnemyWalk(StateMachine, Info);
        _walk.Inizialize();
    }

    private void SetTarget() =>
        _walk.SetTarget(Info.Target.transform);

    public override void Enter() =>
        SetTarget();

    public override void FixedUpdate() =>
        _walk?.FixedUpdate();

    public override void Update()
    {
        if (Info.Target == null)
            StateMachine.ChangeSate<EnemyPatrol>();
        else if (Info.Target != null && Vector2.Distance(Info.transform.position, Info.Target.transform.position) <= Info.AttackDistance)
            StateMachine.ChangeSate<EnemyIdle>();
    }
}
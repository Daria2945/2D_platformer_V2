using UnityEngine;

public class EnemyIdle : EnemyState
{
    public EnemyIdle(StateMachine stateMachine, EnemyMoverInfo enemyMoverInfo) : base(stateMachine, enemyMoverInfo) { }

    public override void Update()
    {
        if (Info.Target == null)
            StateMachine.ChangeSate<EnemyPatrol>();
        else if (Info.Target != null && Vector2.Distance(Info.transform.position, Info.Target.transform.position) > Info.AttackDistance)
            StateMachine.ChangeSate<EnemyChest>();
    }
}
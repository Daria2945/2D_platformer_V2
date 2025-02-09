public class EnemyState : CharacterState
{
    protected EnemyMoverInfo Info;

    public EnemyState(StateMachine stateMachine, EnemyMoverInfo enemyMoverInfo) : base(stateMachine, enemyMoverInfo.Enemy)
    {
        Info = enemyMoverInfo;
    }
}
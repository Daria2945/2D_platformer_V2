public class EnemyStateMachine : StateMachine
{
    public EnemyStateMachine(EnemyMoverInfo enemyMoverInfo)
    {
        InitializeStates(enemyMoverInfo);
    }

    private void InitializeStates(EnemyMoverInfo enemyMoverInfo)
    {
        AddState(new EnemyPatrol(this, enemyMoverInfo));
        AddState(new EnemyChest(this, enemyMoverInfo));
        AddState(new EnemyIdle(this, enemyMoverInfo));

        SetSate<EnemyPatrol>();
    }
}
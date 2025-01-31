public class EnemyState : CharacterState
{
    protected EnemyMoverInfo Info;

    public EnemyState(EnemyMoverInfo enemyMoverInfo) : base(enemyMoverInfo.Enemy)
    {
        Info = enemyMoverInfo;
    }
}
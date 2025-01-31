public class EnemyChest : EnemyState
{
    private Player _target;
    private EnemyWalk _walk;

    public EnemyChest(EnemyMoverInfo enemyMoverInfo) : base(enemyMoverInfo)
    {
        InitializeWalk();
    }

    private void InitializeWalk()
    {
        _walk = new EnemyWalk(Info);
        _walk.Inizialize();
    }

    public void SetTarget(Player target) => _target = target;

    private void SetTarget() => _walk.SetTarget(_target.transform);

    public override void Enter() => SetTarget();

    public override void FixedUpdate() => _walk?.FixedUpdate();
}
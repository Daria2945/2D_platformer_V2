public class PlayerWalk : PlayerState
{
    public PlayerWalk(PlayerMoverInfo playerMoverInfo) : base(playerMoverInfo) { }

    public override void FixedUpdate()
    {
        ChangerRigidbody.ChangeVelocityX(PlayerMoverInfo.InputReader.Direction, PlayerMoverInfo.MoveSpeed);
    }
}
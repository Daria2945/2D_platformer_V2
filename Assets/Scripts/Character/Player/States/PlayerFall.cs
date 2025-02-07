public class PlayerFall : PlayerState
{
    public PlayerFall(PlayerMoverInfo playerMoverInfo) : base(playerMoverInfo) { }

    public override void Enter()
    {
        Fall();
    }

    public override void FixedUpdate()
    {
        if (PlayerMoverInfo.InputReader.Direction != 0)
            ChangerSpeed.ChangeVelocityX(PlayerMoverInfo.InputReader.Direction, PlayerMoverInfo.MoveSpeed);
    }

    private void Fall()
    {
        Character.Rigidbody.gravityScale = PlayerMoverInfo.FallSpeed;
    }
}
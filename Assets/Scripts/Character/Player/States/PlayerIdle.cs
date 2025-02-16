public class PlayerIdle : PlayerState
{
    public PlayerIdle(StateMachine stateMachine, PlayerMoverInfo playerMoverInfo) : base(stateMachine, playerMoverInfo) { }

    public override void Update()
    {
        if (Info.InputReader.Direction != 0)
            StateMachine.ChangeSate<PlayerWalk>();
        else if (Info.CanJump)
            StateMachine.ChangeSate<PlayerJump>();
        else if (Info.GroundDetector.IsGrounded == false && Info.Player.Rigidbody.velocity.y < 0)
            StateMachine.ChangeSate<PlayerFall>();
    }
}
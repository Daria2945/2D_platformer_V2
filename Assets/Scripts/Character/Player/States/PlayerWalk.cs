public class PlayerWalk : PlayerState
{
    public PlayerWalk(StateMachine stateMachine, PlayerMoverInfo playerMoverInfo) : base(stateMachine, playerMoverInfo) { }

    public override void Update()
    {
        if (Info.InputReader.Direction == 0)
            StateMachine.SetSate<PlayerIdle>();
        else if (Info.CanJump)
            StateMachine.SetSate<PlayerJump>();
        else if (Info.GroundDetector.IsGrounded == false && Info.Player.Rigidbody.velocity.y < 0)
            StateMachine.SetSate<PlayerFall>();
    }

    public override void FixedUpdate()
    {
        ChangerSpeed.ChangeVelocityX(Info.InputReader.Direction, Info.MoveSpeed);
    }
}
public class PlayerFall : PlayerState
{
    public PlayerFall(StateMachine stateMachine, PlayerMoverInfo playerMoverInfo) : base(stateMachine, playerMoverInfo) { }

    public override void Enter()
    {
        Fall();
    }

    public override void Update()
    {
        if (Info.GroundDetector.IsGrounded)
        {
            if (Info.InputReader.Direction == 0)
                StateMachine.SetSate<PlayerIdle>();
            else if (Info.InputReader.Direction != 0)
                StateMachine.SetSate<PlayerWalk>();
        }
    }

    public override void FixedUpdate()
    {
        if (Info.InputReader.Direction != 0)
            ChangerSpeed.ChangeVelocityX(Info.InputReader.Direction, Info.MoveSpeed);
    }

    private void Fall()
    {
        Info.Player.Rigidbody.gravityScale = Info.FallSpeed;
    }
}
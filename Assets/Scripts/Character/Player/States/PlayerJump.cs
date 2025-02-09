public class PlayerJump : PlayerState
{
    public PlayerJump(StateMachine stateMachine, PlayerMoverInfo playerMoverInfo) : base(stateMachine, playerMoverInfo) { }

    public override void Enter()
    {
        Jump();
    }

    public override void Update()
    {
        if (Info.Player.Rigidbody.velocity.y < 0)
            StateMachine.SetSate<PlayerFall>();
    }

    public void Jump()
    {
        Info.Player.Rigidbody.velocity = new UnityEngine.Vector2(Info.Player.Rigidbody.velocity.x, Info.JumpForce);
    }
}
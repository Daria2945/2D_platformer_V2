public class PlayerJump : PlayerState
{
    public PlayerJump(PlayerMoverInfo playerMoverInfo) : base(playerMoverInfo) { }

    public override void Enter()
    {
        Jump();
    }

    public void Jump()
    {
        Character.Rigidbody.velocity = new UnityEngine.Vector2(Character.Rigidbody.velocity.x, PlayerMoverInfo.JumpForce);
    }
}
public abstract class PlayerState : CharacterState
{
    protected PlayerMoverInfo Info;

    public PlayerState(StateMachine stateMachine, PlayerMoverInfo playerMoverInfo) : base(stateMachine, playerMoverInfo.Player)
    {
        Info = playerMoverInfo;
    }
}
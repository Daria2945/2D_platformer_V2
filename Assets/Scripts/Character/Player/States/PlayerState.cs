public abstract class PlayerState : CharacterState
{
    protected PlayerMoverInfo PlayerMoverInfo;

    public PlayerState(PlayerMoverInfo playerMoverInfo) : base(playerMoverInfo.Player)
    {
        PlayerMoverInfo = playerMoverInfo;
    }
}
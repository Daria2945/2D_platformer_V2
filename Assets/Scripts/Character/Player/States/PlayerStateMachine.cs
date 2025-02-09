public class PlayerStateMachine : StateMachine
{
    public PlayerStateMachine(PlayerMoverInfo playerMoverInfo)
    {
        InitializeStates(playerMoverInfo);
    }

    private void InitializeStates(PlayerMoverInfo playerMoverInfo)
    {
        AddState(new PlayerIdle(this, playerMoverInfo));
        AddState(new PlayerWalk(this, playerMoverInfo));
        AddState(new PlayerJump(this, playerMoverInfo));
        AddState(new PlayerFall(this, playerMoverInfo));

        SetSate<PlayerIdle>();
    }
}
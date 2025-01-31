using System.Collections.Generic;

public class ListPlayerStates
{
    private const string Idle = "Idle";
    private const string Walk = "Walk";
    private const string Jump = "Jump";
    private const string Fall = "Fall";

    private Dictionary<string, PlayerState> _states;

    public ListPlayerStates(PlayerMoverInfo playerMoverInfo)
    {
        InitializeStates(playerMoverInfo);
    }

    private void InitializeStates(PlayerMoverInfo playerMoverInfo)
    {
        _states = new Dictionary<string, PlayerState>
        {
            { Idle, new PlayerIdle(playerMoverInfo) },
            { Walk, new PlayerWalk(playerMoverInfo) },
            { Jump, new PlayerJump(playerMoverInfo) },
            { Fall, new PlayerFall(playerMoverInfo) }
        };

        foreach (var state in _states)
            state.Value.Inizialize();
    }

    public PlayerState GetState(float direction, float velocityY, bool canJump, bool isGround)
    {
        bool isMove = direction != 0 && isGround;
        bool isJump = canJump && isGround;
        bool isFall = velocityY < 0;
        bool isIdle = direction == 0 && isGround;

        if (isJump)
            return _states[Jump];
        else if (isMove)
            return _states[Walk];
        else if(isFall)
            return _states[Fall];
        else if(isIdle)
            return _states[Idle];

        return null;
    }
}
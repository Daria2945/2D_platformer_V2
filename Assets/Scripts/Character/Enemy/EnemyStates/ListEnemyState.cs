using System.Collections.Generic;

public class ListEnemyState
{
    private const string Patrol = "Patrol";
    private const string Chest = "Chest";
    private const string Idle = "Idle";

    private Dictionary<string, EnemyState> _states;

    public ListEnemyState(EnemyMoverInfo enemyMoverInfo)
    {
        InitializeStates(enemyMoverInfo);
    }

    private void InitializeStates(EnemyMoverInfo enemyMoverInfo)
    {
        _states = new Dictionary<string, EnemyState>
        {
            { Patrol, new EnemyPatrol(enemyMoverInfo) },
            { Chest, new EnemyChest(enemyMoverInfo) },
            { Idle, new EnemyIdle(enemyMoverInfo) },
        };
    }

    public void StartPatrol(out EnemyState currentState)
    {
        currentState = _states[Patrol];
        currentState.Enter();
    }

    public void StartChest(Player player, out EnemyState currentState)
    {
        currentState = _states[Chest];

        ((EnemyChest)currentState).SetTarget(player);
        currentState.Enter();
    }

    public void StartAttack(out EnemyState currentState)
    {
        currentState = _states[Idle];
    }
}

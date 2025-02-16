using System;
using System.Collections.Generic;

public class StateMachine
{
    private Dictionary<Type, CharacterState> _states = new();

    public CharacterState CurrentState { get; private set; }

    public void AddState(CharacterState state)
    {
        _states.Add(state.GetType(), state);
        _states[state.GetType()].Inizialize();
    }

    public void ChangeSate<T>() where T : CharacterState
    {
        var type = typeof(T);

        if (CurrentState != null && CurrentState.GetType() == type)
            return;

        if (_states.TryGetValue(type, out CharacterState newState))
        {
            CurrentState = newState;
            CurrentState?.Enter();
        }
    }

    public void FixedUpdate()
    {
        CurrentState?.FixedUpdate();
    }

    public void Update()
    {
        CurrentState?.Update();
    }
}
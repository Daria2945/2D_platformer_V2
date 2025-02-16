using System;
using UnityEngine;

public class CharacterAnimationEvent : MonoBehaviour
{
    public event Action Attacking;
    public event Action Died;

    public void InvokeAttackingEvent() =>
        Attacking?.Invoke();

    public void InvokeDeadEvent() =>
        Died?.Invoke();
}
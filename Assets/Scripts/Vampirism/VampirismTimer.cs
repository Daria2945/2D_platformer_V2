using System;
using System.Collections;
using UnityEngine;

public class VampirismTimer : MonoBehaviour
{
    [SerializeField] private TimerView _timerView;

    [SerializeField] private float _abilityDuration;
    [SerializeField] private float _reloadTime;

    public event Action AbilityExpired;
    public event Action ReloadFinished;

    public void StartCounting()
    {
        StartCoroutine(Updating(_abilityDuration, AbilityExpired));
        _timerView.StartCounting(_abilityDuration);
    }

    public void Reload()
    {
        StartCoroutine(Updating(_reloadTime, ReloadFinished));
        _timerView.Reload(_reloadTime);
    }

    private IEnumerator Updating(float delay, Action action = null)
    {
        yield return new WaitForSecondsRealtime(delay);

        if (action != null)
            action?.Invoke();
    }
}
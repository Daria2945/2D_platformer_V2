using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VampirismTimerBar : MonoBehaviour
{
    private const string Text = "Timer Vampirizm";

    [SerializeField] private Image _visual;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private float _abilityDuration;
    [SerializeField] private float _reloadTime;

    private float _startFillValue = 0;
    private float _endFillValue = 1;

    public event Action AbilityExpired;
    public event Action ReloadFinished;

    private void Start()
    {
        _visual.fillAmount = _endFillValue;
    }

    public void StartCounting()
    {
        StartCoroutine(Updating(_abilityDuration, _startFillValue, action: AbilityExpired));
    }

    public void Reload()
    {
        StartCoroutine(Updating(_reloadTime, _endFillValue, action: ReloadFinished));
    }

    private IEnumerator Updating(float delay, float targetValue, Action action = null)
    {
        float elepsedTime = 0;
        float stepSmooth = _endFillValue / delay;

        while(_visual.fillAmount != targetValue)
        {
            _visual.fillAmount = Mathf.MoveTowards(_visual.fillAmount, targetValue, stepSmooth * Time.deltaTime);

            yield return null;

            elepsedTime += Time.deltaTime;
            _text.text = ((int)elepsedTime).ToString();
        }

        _text.text = Text;

        if(action != null)
            action?.Invoke();
    }
}
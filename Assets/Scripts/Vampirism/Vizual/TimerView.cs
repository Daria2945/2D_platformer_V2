using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    private const string Text = "Timer Vampirizm";

    [SerializeField] private Image _visual;
    [SerializeField] private TextMeshProUGUI _text;

    private float _startFillValue = 0;
    private float _endFillValue = 1;

    private Coroutine _coroutine;

    private void Start()
    {
        _visual.fillAmount = _endFillValue;
    }

    public void StartCounting(float delay)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Updating(delay, _startFillValue));
    }

    public void Reload(float delay)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Updating(delay, _endFillValue));
    }

    private IEnumerator Updating(float delay, float targetValue)
    {
        float elepsedTime = 0;
        float stepSmooth = _endFillValue / delay;

        while (_visual.fillAmount != targetValue)
        {
            _visual.fillAmount = Mathf.MoveTowards(_visual.fillAmount, targetValue, stepSmooth * Time.deltaTime);

            yield return null;

            elepsedTime += Time.deltaTime;
            _text.text = ((int)elepsedTime).ToString();
        }

        _text.text = Text;
    }
}
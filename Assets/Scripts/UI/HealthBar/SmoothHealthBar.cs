using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField, Range(0, 1)] private float _smoothStep;
    
    private Character _character;

    private Coroutine _coroutine;
    private bool _isWorkCoroutine;

    public void Initialize(Character character)
    {
        _character = character;

        UpdateValue(_character.MaxHealth);

        _character.Health.ChangedValue += UpdateValue;
    }

    private void OnDisable()
    {
        _character.Health.ChangedValue -= UpdateValue;
    }

    private void UpdateValue(int currentHealth)
    {
        if (_isWorkCoroutine)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(UpdatingValue(currentHealth));
    }

    private IEnumerator UpdatingValue(int currentHealth)
    {
        float nextValue = (float)currentHealth / _character.MaxHealth;

        while (_slider.value != nextValue)
        {
            _isWorkCoroutine = _slider.value != nextValue;
            _slider.value = Mathf.MoveTowards(_slider.value, nextValue, _smoothStep * Time.deltaTime);

            yield return null;
        }

        _isWorkCoroutine = false;
    }
}
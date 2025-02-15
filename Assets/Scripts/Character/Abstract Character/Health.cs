using System;

public class Health
{
    private int _maxValue;
    private int _currentValue;
    private int _minValue;

    public event Action<int> ChangedValue;
    public event Action Died;

    public Health(int maxValue)
    {
        if (maxValue <= 0)
        {
            _maxValue = 1;
            _currentValue = _maxValue;

            return;
        }

        _maxValue = maxValue;
        _currentValue = maxValue;
        _minValue = 0;
    }

    public void TakeDamage(int damage)
    {
        int nextValue = _currentValue - damage;

        if (nextValue <= _minValue)
        {
            _currentValue = _minValue;
            Died?.Invoke();
        }
        else
        {
            _currentValue = nextValue;
        }

        ChangedValue?.Invoke(_currentValue);
    }

    public void ReceiveTreatment(int unitHealth)
    {
        int nextHealth = _currentValue + unitHealth;

        if (nextHealth >= _maxValue)
            _currentValue = _maxValue;
        else
            _currentValue = nextHealth;

        ChangedValue?.Invoke(_currentValue);
    }
}
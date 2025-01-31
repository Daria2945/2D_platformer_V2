using System;

public class CharacterHealth
{
    protected int MaxHealth;
    protected int CurrentHealth;
    protected int MinHealth;

    public event Action Died;

    public CharacterHealth(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        MinHealth = 0;
    }

    public void TakeDamage(int damage)
    {
        int nextHealth = CurrentHealth - damage;

        if (nextHealth <= MinHealth)
        {
            CurrentHealth = MinHealth;
            Died?.Invoke();
        }
        else
        {
            CurrentHealth = nextHealth;
        }
    }

    public void Healed(int unitHealth)
    {
        int nextHealth = CurrentHealth + unitHealth;

        if (nextHealth >= MaxHealth)
            CurrentHealth = MaxHealth;
        else
            CurrentHealth = nextHealth;
    }
}
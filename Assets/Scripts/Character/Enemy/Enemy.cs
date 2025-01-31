public class Enemy : Character
{
    protected virtual void OnEnable()
    {
        Health.Died += PlayDeathAnimation;
        Events.Died += Die;
    }

    protected virtual void OnDisable()
    {
        Health.Died -= PlayDeathAnimation;
        Events.Died -= Die;
    }
}
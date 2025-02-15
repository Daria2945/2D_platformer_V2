using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Character : MonoBehaviour
{
    [SerializeField] private AnimationSwicher _animationSwicher;
    [SerializeField] private CharacterAnimationEvent _events;

    [Header(" ")]
    [SerializeField] private int _maxHealth;

    private Health _health;

    public AnimationSwicher AnimationSwicher => _animationSwicher;
    public CharacterAnimationEvent Events => _events;
    public Health Health => _health;
    public int MaxHealth => _maxHealth;
    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void InitializeHealth()
    {
        _health = new Health(_maxHealth);
    }

    protected void PlayDeathAnimation()
    {
        _animationSwicher.StopLive();
        _animationSwicher.Die();
    }

    protected void Die()
    {
        gameObject.SetActive(false);
    }
}
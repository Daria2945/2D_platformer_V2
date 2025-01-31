using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Character : MonoBehaviour
{
    [SerializeField] private AnimationSwicher _animationSwicher;
    [SerializeField] private CharacterAnimationEvents _events;

    [Header(" ")]
    [SerializeField] private int _maxHealth;

    private CharacterHealth _health;

    public AnimationSwicher AnimationSwicher => _animationSwicher;
    public CharacterAnimationEvents Events => _events;
    public CharacterHealth Health => _health;
    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _health = new CharacterHealth(_maxHealth);
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
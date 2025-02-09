using UnityEngine;

[RequireComponent(typeof(Character))]
public abstract class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackCooldown;

    [SerializeField] private CharacterAnimationEvent _animationEvents;

    private Character _character;

    protected Character Target;
    protected float AttackCooldown => _attackCooldown;

    private void Start()
    {
        _character = GetComponent<Character>();
    }

    private void OnEnable()
    {
        _animationEvents.Attacking += Attack;
    }

    private void OnDisable()
    {
        _animationEvents.Attacking -= Attack;
    }

    protected void PlayAttackAnimation() => _character.AnimationSwicher.Attack();

    private void Attack()
    {
        if (Target == null)
            return;

        Target.AnimationSwicher.TakeDamage();
        Target.Health.TakeDamage(_damage);
    }
}
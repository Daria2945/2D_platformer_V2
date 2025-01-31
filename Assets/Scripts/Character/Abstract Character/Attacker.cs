using UnityEngine;

[RequireComponent(typeof(Character))]
public abstract class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackCooldown;

    [SerializeField] private CharacterAnimationEvents _animationEvents;

    protected Character Target;

    protected Character Character { get; private set; }
    protected WaitForSecondsRealtime Wait { get; private set; }

    private void Start()
    {
        Character = GetComponent<Character>();
        Wait = new WaitForSecondsRealtime(_attackCooldown);
    }

    private void OnEnable()
    {
        _animationEvents.Attacking += Attack;
    }

    private void OnDisable()
    {
        _animationEvents.Attacking -= Attack;
    }

    private void Attack()
    {
        if (Target == null)
            return;

        Target.AnimationSwicher.TakeDamage();
        Target.Health.TakeDamage(_damage);
    }
}
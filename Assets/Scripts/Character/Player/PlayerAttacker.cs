using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player), typeof(InputReader))]
public class PlayerAttacker : Attacker
{
    [SerializeField] private EnemyDetector _enemyDetector;

    private InputReader _inputReader;
    private bool _canAttack;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _canAttack = true;
    }

    private void Update()
    {
        if (_inputReader.CanAttack())
            AttackEnemy();
    }

    private void AttackEnemy()
    {
        if (_enemyDetector.TryGetEnemy(out Enemy enemy) && _canAttack)
        {
            Target = enemy;

            StartCoroutine(StartCooldown());
            Character.AnimationSwicher.Attack();

            return;
        }
        else if (_enemyDetector.TryGetEnemy(out Enemy _) == false)
        {
            Target = null;
            _canAttack = true;

            Character.AnimationSwicher.Attack();
        }
    }

    private IEnumerator StartCooldown()
    {
        _canAttack = false;

        yield return Wait;

        _canAttack = true;

        yield break;
    }
}
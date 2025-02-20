using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(Character))]
public class Vampirism : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage = 1;
    [SerializeField] private VampirismTimerBar _timer;
    [SerializeField] private VampirismDetector _detector;

    private InputReader _inputReader;
    private Character _character;

    private Coroutine _coroutine;
    private float _attackCooldown = 1f;

    private bool _canAttack;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _character = GetComponent<Character>();

        _canAttack = true;
    }

    private void OnEnable()
    {
        _inputReader.VampirismButtonPressed += Attack;

        _timer.AbilityExpired += Reload;
        _timer.ReloadFinished += FinalizeReload;
    }

    private void OnDisable()
    {
        _inputReader.VampirismButtonPressed -= Attack;

        _timer.AbilityExpired -= Reload;
        _timer.ReloadFinished -= FinalizeReload;
    }

    private void Attack()
    {
        if (_canAttack == false)
            return;

        _canAttack = false;
        _coroutine = StartCoroutine(Attacking());

        _timer.StartCounting();
        _detector.StartFind();
    }

    private void Reload()
    {
        _timer.Reload();
        _detector.StopFind();

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void FinalizeReload()
    {
        _canAttack = true;
    }

    private IEnumerator Attacking()
    {
        List<Enemy> enemies;
        var wait = new WaitForSeconds(_attackCooldown);

        while (enabled)
        {
            enemies = _detector.GetFoundEnemies();

            foreach (Enemy enemy in enemies)
            {
                enemy.Health.TakeDamage(_damage);
                _character.Health.ReceiveTreatment(_damage);
            }

            yield return wait;
        }
    }
}
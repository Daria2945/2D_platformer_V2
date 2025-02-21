using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(Character))]
public class Vampirism : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage = 1;
    [SerializeField] private VampirismTimer _timer;
    [SerializeField] private VampirismDetector _detector;
    [SerializeField] private RadiusView _radiusView;

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
        _radiusView.Show();
    }

    private void Reload()
    {
        _timer.Reload();
        _radiusView.Hide();

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void FinalizeReload()
    {
        _canAttack = true;
    }

    private IEnumerator Attacking()
    {
        Enemy enemy;
        var wait = new WaitForSeconds(_attackCooldown);

        while (enabled)
        {
            enemy = _detector.GetNearestEnemy();

            if (enemy != null)
            {
                _character.Health.ReceiveTreatment(enemy.Health.GetUnitHealth(_damage));
                enemy.Health.TakeDamage(_damage);
            }

            yield return wait;
        }
    }
}
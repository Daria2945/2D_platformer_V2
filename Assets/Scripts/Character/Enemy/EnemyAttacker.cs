using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMoverInfo))]
public class EnemyAttacker : Attacker
{
    private EnemyMoverInfo _info;
    private Coroutine _coroutine;

    private bool _isWorkCoroutine;

    private void Awake()
    {
        _info = GetComponent<EnemyMoverInfo>();
    }

    private void Update()
    {
        if (_info.Target != null)
        {
            if (Vector2.Distance(transform.position, _info.Target.transform.position) <= _info.AttackDistance)
                StartAttack();
            else
                StopAttack();
        }
        else
        {
            StopAttack();
        }
    }

    private void StartAttack()
    {
        if (_isWorkCoroutine == false)
        {
            Target = _info.Target;
            _isWorkCoroutine = true;

            _coroutine = StartCoroutine(Attack());
        }
    }

    private void StopAttack()
    {
        if (_isWorkCoroutine)
        {
            Target = null;
            _isWorkCoroutine = false;

            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            PlayAttackAnimation();

            yield return Wait;
        }
    }
}
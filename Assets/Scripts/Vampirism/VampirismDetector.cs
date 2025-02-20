using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VampirismDetector : MonoBehaviour
{
    private const float DetectorRadius = 3f;
    private const float Delay = 0.2f;

    [SerializeField] private LayerMask _layerMask;

    private SpriteRenderer _alphaRadius;
    private Color _alphaValueActiveRadius = new(1f, 1f, 1f, 0.5f);
    private Color _alphaValueInactiveRadius = new(1f, 1f, 1f, 0f);

    private Coroutine _coroutine;
    private bool _isCoroutineWork;

    private List<Enemy> _enemies = new();

    private void Awake()
    {
        _alphaRadius = GetComponent<SpriteRenderer>();
        _alphaRadius.material.color = _alphaValueInactiveRadius;
    }

    public List<Enemy> GetFoundEnemies()
    {
        List<Enemy> enemies = new();

        enemies.AddRange(_enemies);

        return enemies;
    }

    public void StartFind()
    {
        if (_isCoroutineWork)
            return;

        _isCoroutineWork = true;

        _coroutine = StartCoroutine(FindingEnemies());
        _alphaRadius.material.color = _alphaValueActiveRadius;
    }

    public void StopFind()
    {
        if (_isCoroutineWork == false)
            return;

        if (_coroutine != null)
        {
            _isCoroutineWork = false;

            StopCoroutine(_coroutine);
            _enemies.Clear();
            _alphaRadius.material.color = _alphaValueInactiveRadius;
        }

    }

    private void FindEnemies()
    {
        List<Enemy> enemies = new();
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, DetectorRadius);

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out Enemy enemy))
            {
                enemies.Add(enemy);
            }
        }

        _enemies = enemies;
    }

    private IEnumerator FindingEnemies()
    {
        var wait = new WaitForSeconds(Delay);

        while (enabled)
        {
            FindEnemies();

            yield return wait;
        }
    }
}
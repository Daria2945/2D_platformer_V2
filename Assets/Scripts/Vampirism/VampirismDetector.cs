using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class VampirismDetector : MonoBehaviour
{
    private List<Enemy> _enemies = new();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            _enemies.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            _enemies.Remove(enemy);
    }

    public Enemy GetNearestEnemy()
    {
        float minDistance = float.MaxValue;
        Enemy nearestEnemy = null;

        foreach (Enemy enemy in _enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
}
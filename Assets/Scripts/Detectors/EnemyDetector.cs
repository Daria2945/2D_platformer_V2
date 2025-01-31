using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private float _distanceAttack;
    [SerializeField] private LayerMask _enemyLayerMask;

    public bool TryGetEnemy(out Enemy enemy)
    {
        RaycastHit2D hit;
        enemy = null;

        hit = Physics2D.Raycast(transform.position, transform.right, _distanceAttack, _enemyLayerMask);

        if (hit.transform != null)
            hit.transform.TryGetComponent(out enemy);

        return enemy != null;
    }
}
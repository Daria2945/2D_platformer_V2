using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PlayerDetector : MonoBehaviour
{
    public event Action<Player> PlayerFound;
    public event Action PlayerLost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
            PlayerFound?.Invoke(player);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _))
            PlayerLost?.Invoke();
    }
}
using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<Coin> CoinFound;
    public event Action<Potion> PotionFound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
            CoinFound?.Invoke(coin);

        if (collision.TryGetComponent(out Potion potion))
            PotionFound?.Invoke(potion);
    }
}
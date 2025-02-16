using System;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public event Action<Coin> CoinFound;
    public event Action<Potion> PotionFound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            if (item is Coin coin)
                CoinFound?.Invoke(coin);

            if (item is Potion potion)
                PotionFound?.Invoke(potion);
        }
    }
}
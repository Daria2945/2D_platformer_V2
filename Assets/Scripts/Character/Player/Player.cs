using UnityEngine;

public class Player : Character
{
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        Health.Died += PlayDeathAnimation;
        Events.Died += Die;

        _collisionDetector.PotionFound += Healed;
        _collisionDetector.CoinFound += CollectCoin;
    }

    private void OnDisable()
    {
        Health.Died += PlayDeathAnimation;
        Events.Died += Die;

        _collisionDetector.PotionFound -= Healed;
        _collisionDetector.CoinFound -= CollectCoin;
    }

    private void Healed(Potion potion)
    {
        Health.Healed(potion.RegenerationUnits);
        potion.Hide();
    }

    private void CollectCoin(Coin coin)
    {
        _wallet.CollectCoin();
        coin.Hide();
    }
}
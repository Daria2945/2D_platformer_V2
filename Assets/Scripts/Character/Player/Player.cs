using UnityEngine;

public class Player : Character
{
    [SerializeField] private ItemDetector _itemDetector;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        Health.Died += PlayDeathAnimation;
        Events.Died += Die;

        _itemDetector.PotionFound += ReceiveTreatment;
        _itemDetector.CoinFound += CollectCoin;
    }

    private void OnDisable()
    {
        Health.Died += PlayDeathAnimation;
        Events.Died += Die;

        _itemDetector.PotionFound -= ReceiveTreatment;
        _itemDetector.CoinFound -= CollectCoin;
    }

    private void ReceiveTreatment(Potion potion)
    {
        Health.ReceiveTreatment(potion.RegenerationUnits);
        potion.Hide();
    }

    private void CollectCoin(Coin coin)
    {
        _wallet.CollectCoin();
        coin.Hide();
    }
}